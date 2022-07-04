using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyTuyenSinh.Shared
{
    [NotMapped]
    public class AnhUpload
    {
        public string anh;
        public int status;
        public AnhUpload()
        {

        }

        public AnhUpload(string anh)
        {
            this.anh = anh;
            this.status = 1;
        }
    }
}
