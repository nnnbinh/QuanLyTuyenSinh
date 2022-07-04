using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTuyenSinh.Shared
{
    public class HinhAnh
    {
        public int Id { get; set; }
        public string Image { get; set; } = String.Empty;
        public ThiSinh ThiSinh { get; set; }
    }
}
