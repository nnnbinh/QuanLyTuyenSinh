using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyTuyenSinh.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThiSinhController : ControllerBase
    {
        private readonly DataContext _context;
        public ThiSinhController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThiSinh>>> GetThiSinh()
        {
            var ThiSinhs = await _context.ThiSinh.ToListAsync();
            return Ok(ThiSinhs);
        }

        [HttpPost]
        public async Task<ActionResult<List<ThiSinh>>> CreateThiSinh(ThiSinh thiSinh)
        {
            _context.ThiSinh.Add(thiSinh);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
