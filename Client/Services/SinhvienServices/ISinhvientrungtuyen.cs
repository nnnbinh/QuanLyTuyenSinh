using QuanLyTuyenSinh.Shared.PageSetUp;

namespace QuanLyTuyenSinh.Client.Services.SinhvienServices
{
    public interface ISinhvientrungtuyen
    {
        List<ThiSinh> thisinhs { get; set; }
        Task Getthisinh();
        Task<ThiSinh> GetSingleThisinh(int id);
        Task CreateThiSinh(ThiSinh thiSinh,List<AnhUpload> anhUploads,int userId);
        Task UpdateThiSinh(ThiSinh thiSinh, List<AnhUpload> anhUploads,int userId);
        Task DeleteThiSinh(int id);
        Task GetChartData();

        double[] data { get; set; }
    }
}
