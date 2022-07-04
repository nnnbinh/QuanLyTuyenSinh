namespace QuanLyTuyenSinh.Server.Service.HinhAnhService
{
    public interface IHinhAnhService
    {
        Task<string> UploadFile(string file);
        bool DeleteFile(string filePath);
    }
}
