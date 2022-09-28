using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTuyenSinh.Shared
{
    public class ForgotPassDto
    {
        [Required]
        public string Username { get; set; }
    }
}
