using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyTuyenSinh.Shared.PageSetUp;

namespace QuanLyTuyenSinh.Shared
{
    [NotMapped]
    public class ThiSinhData
    {
        public List<AnhUpload>? images { get; set; }
        public int userId { get; set; }
        public ThiSinh thiSinh { get; set; }

        public ThiSinhData()
        {

        }

        public ThiSinhData(List<AnhUpload> images, ThiSinh thiSinh)
        {
            this.images = images;
            this.thiSinh = thiSinh;
        }

        public ThiSinhData(List<AnhUpload> images, ThiSinh thiSinh,int userId)
        {
            this.images = images;
            this.thiSinh = thiSinh;
            this.userId = userId;
        }
    }
}
