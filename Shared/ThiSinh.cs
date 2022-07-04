using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuanLyTuyenSinh.Shared
{
    public class ThiSinh
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập Họ Tên")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập CMND")]
        public string Cmnd { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        public string NgaySinh { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn bật học")]
        public string BacHoc { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mã ngành xét tuyển")]
        public string MaNganhXetTuyen { get; set; }

        public string? DoiTuong { get; set; }
        public int DiemUuTienDT { get; set; }

        public string? KhuVuc { get; set; }

        public double DiemUuTienKV { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn khối ngành xét tuyển")]
        public string KhoiXetTuyen { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public string? Mon1 { get; set; } = "1";
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public string? Mon2 { get; set; } = "2";
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public string? Mon3 { get; set; } = "3";
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem1111 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem1211 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem1112 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem1212 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem1TB12 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem2111 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem2211 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem2112 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem2212 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem2TB12 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem3111 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem3211 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem3112 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem3212 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double Diem3TB12 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double DiemTBPT1 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double DiemTBPT2 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double DiemTBPT3 { get; set; } = 1;

        public string TruongTHPT { get; set; } = "1";

        public string HK11 { get; set; } = "1";

        public string HK12 { get; set; } = "1";

        public int? MaDKXT { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        public double diem1 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm 1")]
        public double diem2 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm 2")]
        public double diem3 { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập điểm 3")]
        public double Tong { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Sdt { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        [Required]
        public string Diachi { get; set; } = "1";

        public DateTime Ngaygui { get; set; } = DateTime.Now;
        [Required]
        public string? CBTuVan { get; set; } = "1";
        [Required]
        public string TrangThai { get; set; } = "1";

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
        public List<HinhAnh> HinhAnhs { get; set; } = new List<HinhAnh>();
        public User? User { get; set; }
    }
}
