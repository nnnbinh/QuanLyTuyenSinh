using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace QuanLyTuyenSinh.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService userService;
        private readonly DataContext _context;
        private readonly IEmailSender sendMailService;

        public AuthController(IConfiguration configuration,IUserService userService,DataContext context,IEmailSender sendMailService)
        {
            _configuration = configuration;
            this.userService = userService;
            _context = context;
            this.sendMailService = sendMailService;
        }

        [HttpGet,Authorize]
        public ActionResult<object> GetMe()
        {
            var username = userService.getMyId();
            return Ok(username);
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            if(_context.User.Any(u=>u.Username == request.Username))
            {
                return BadRequest("User already Exist");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User userReg = new User();
            userReg.Username = request.Username;
            userReg.PasswordHash = passwordHash;
            userReg.PasswordSalt = passwordSalt;
            userReg.Roles = request.Roles;
            userReg.VerifyToken = CreateRandomToken();

            var ip = HttpContext.Request.Host.Value;
            string url = "http://" + ip + "/api/Auth/verify?token=" + userReg.VerifyToken;

            await sendMailService.SendEmailAsync(userReg.Username, "Xác nhận Đăng ký", "Verified at: " + url);

            _context.User.Add(userReg);
            await _context.SaveChangesAsync();
            return Ok("Please check email");
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Roles),
                new Claim("UserId",user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("MySecretKey:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: cred);
            
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var result = _context.User.Include(ts => ts.ThiSinhs).FirstOrDefault(user => user.Username == request.Username);
            if(result == null)
            {
                return BadRequest("User not found");
            }
            if(!VerifyPasswordHash(request.Password, result.PasswordHash,result.PasswordSalt))
            {
                return BadRequest("Password incorrect");
            }
            if(result.VerifyAt == null)
            {
                return BadRequest("Not Verified!");
            }

            string token = CreateToken(result);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken,ref result);
            await _context.SaveChangesAsync();

            return Ok(token);
        }

        private void SetRefreshToken(RefreshToken refreshToken,ref User user)
        {
            var cookieOption = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expired
            };
            Response.Cookies.Append("refreshToken",refreshToken.Token,cookieOption);
            user.Token = refreshToken.Token;
            user.TokenExpired = refreshToken.Expired;
            user.TokenCreated = refreshToken.Created;

        }

        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expired = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };
            return refreshToken;
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<string>> RefreshToken([FromBody]string userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == Int32.Parse(userId));
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.Token.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpired < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, ref user);
            await _context.SaveChangesAsync();

            return Ok(token);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        [HttpGet("verify")]
        public async Task<IActionResult> Verify(string token)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.VerifyToken == token);
            if (user == null)
            {
                return BadRequest("Invalid token.");
            }

            user.VerifyAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok("User verified! :)");
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPassDto forgotPassDto)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == forgotPassDto.Username);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            

            user.PasswordResetToken = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            var ip = HttpContext.Request.Host.Value;
            string url = "https://" + ip + "/api/Auth/verify-forgot?token=" + user.PasswordResetToken;
            await sendMailService.SendEmailAsync(user.Username, "Xác nhận Đổi mật khẩu", "Verified at: " + url);

            await _context.SaveChangesAsync();

            return Ok("Please check your email.");
        }

        [HttpGet("verify-forgot")]
        public async Task<IActionResult> VerifyForgot(string token)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.PasswordResetToken == token);
            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Invalid Token.");
            }

            user.VerifyResetAt = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok("You may now reset your password");
        }

        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || user.VerifyResetAt == null)
            {
                return BadRequest("Cannot change Password");
            }

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.PasswordResetToken = null;
            user.ResetTokenExpires = null;
            user.VerifyResetAt = null;

            await _context.SaveChangesAsync();

            return Ok("Password successfully reset.");
        }
    }
}