﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyTuyenSinh.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ThiSinhController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _environment;

        public ThiSinhController(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThiSinh>>> GetThiSinh()
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).Include(ts=>ts.User).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ThiSinh>>> CreateThiSinh(ThiSinhData thiSinhData)
        {
            var result = _context.User.Include(ts => ts.ThiSinhs).FirstOrDefault(user => user.Id == thiSinhData.userId);

            thiSinhData.images.ForEach( item =>
			{
				HinhAnh image = new HinhAnh();
                image.Image = item.anh;
				thiSinhData.thiSinh.HinhAnhs.Add(image);
			});

            thiSinhData.thiSinh.User = result; 

            _context.ThiSinh.Add(thiSinhData.thiSinh);

			await _context.SaveChangesAsync();
            return Ok(await GetDbThiSinh());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ThiSinh>> GetThiSinh(int id)
        {
            var result = await _context.ThiSinh.Include(i => i.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);

            if (result == null)
            {
                return NotFound("Không tìm thấy thí sinh");
            }
            return Ok(result);
        }

        [HttpGet("userItem/{userid}")]
        public async Task<ActionResult<ThiSinh>> GetThiSinhByUser(int userid)
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).Where(ts=> ts.User.Id==userid).ToListAsync();

            if (result == null)
            {
                return NotFound("Không tìm thấy thí sinh");
            }
            return Ok(result);
        }

        [HttpGet("data")]
        public ActionResult<double[]> GetDataChart()
        {
            var pending = _context.ThiSinh.Where(ts => ts.TrangThai == "Pending").Count();
            var accept = _context.ThiSinh.Where(ts => ts.TrangThai == "Accepted").Count();
            var reject = _context.ThiSinh.Where(ts => ts.TrangThai == "Rejected").Count();
            List<double> result = new List<double>();
            result.Add(pending);
            result.Add(accept);
            result.Add(reject);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ThiSinh>>> UpdateThiSinh(ThiSinhData thiSinhData)
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == thiSinhData.thiSinh.Id);
            var user = _context.User.Include(ts => ts.ThiSinhs).FirstOrDefault(user => user.Id == thiSinhData.userId);

            if (result == null)
            {
                return NotFound("Không tìm thấy thí sinh");
            }

			thiSinhData.images.ForEach( item =>
			{
                if (item.status == 0) // moi
                {
                    HinhAnh image = new HinhAnh();
                    image.Image = item.anh;
                    result.HinhAnhs.Add(image);
                }else if(item.status == 2)//xoa
                {
                    var name = item.anh;
                    result.HinhAnhs.RemoveAll(i => i.Image == name);
                }
			});

            thiSinhData.thiSinh.User = user;


            foreach (PropertyInfo prop in result.GetType().GetProperties())
            {
                if (prop.Name != "Id" && prop.Name != "HinhAnhs" && prop.Name != "User")
                {
                    prop.SetValue(result, prop.GetValue(thiSinhData.thiSinh));
                }
            }

            await _context.SaveChangesAsync();
            return Ok(await GetDbThiSinh());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ThiSinh>>> DeleteThiSinh(int id)
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);
            if (result == null)
            {
                return NotFound("Khong tim thay thi sinh");
            }
            _context.HinhAnh.RemoveRange(result.HinhAnhs);
            _context.ThiSinh.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await GetDbThiSinh());
        }

        private async Task<List<ThiSinh>> GetDbThiSinh()
        {
            return await _context.ThiSinh.Include(ts => ts.HinhAnhs).ToListAsync();
        }
     }
}
