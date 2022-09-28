namespace QuanLyTuyenSinh.Server.Data
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ThiSinh> ThiSinh { get; set; }
        public DbSet<HinhAnh> HinhAnh { get; set; }
        public DbSet<User> User { get; set; }
    }
}
