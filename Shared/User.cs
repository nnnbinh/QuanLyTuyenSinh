using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTuyenSinh.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Roles { get; set; } = "Thi sinh";
        public ICollection<ThiSinh> ThiSinhs { get; set; }
        public string VerifyToken { get; set; }
        public DateTime? VerifyAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? VerifyResetAt { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime TokenCreated {get; set; } 
        public DateTime TokenExpired { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
    }
}
