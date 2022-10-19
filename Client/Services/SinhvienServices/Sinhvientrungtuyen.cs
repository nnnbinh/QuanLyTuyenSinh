using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace QuanLyTuyenSinh.Client.Services.SinhvienServices
{
    public class Sinhvientrungtuyen : ISinhvientrungtuyen
    {
        private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;

		public Sinhvientrungtuyen(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<ThiSinh> thisinhs { get; set; } = new List<ThiSinh>();
        public double[] data { get; set; } = new double[3];
        public HttpClient Http { get; }

        public async Task CreateThiSinh(ThiSinh thiSinh,List<AnhUpload> anhUploads,int userId)
        {
            ThiSinhData thiSinhData = new ThiSinhData(anhUploads, thiSinh,userId);
            using (var content = new StringContent(JsonConvert.SerializeObject(thiSinhData), System.Text.Encoding.UTF8, "application/json"))
            {
                var result =  await _http.PostAsync("api/thisinh", content);
                await SetThiSinhssr(result);
            }
        }

		private async Task SetThiSinhssr(HttpResponseMessage result)
		{
			var response =await result.Content.ReadFromJsonAsync<List<ThiSinh>>();
            thisinhs = response;
            _navigationManager.NavigateTo("sinhvienss");
		}

		public async Task DeleteThiSinh(int id)
        {
            var result = await _http.DeleteAsync($"api/thisinh/{id}");
            await SetThiSinhssr(result);
        }

        public async Task<ThiSinh> GetSingleThisinh(int id)
        {
            var result = await _http.GetFromJsonAsync<ThiSinh>($"api/thisinh/{id}");
            if (result != null)
                return result;
            throw new Exception("Sinh Vien khong ton tai");
        }

        public async Task Getthisinh()
        {
            var result = await _http.GetFromJsonAsync<List<ThiSinh>>("api/thisinh");
            if (result != null)
                thisinhs = result;

        }

        public async Task UpdateThiSinh(ThiSinh thiSinh, List<AnhUpload> anhUploads,int userId)
        {
            ThiSinhData thiSinhData = new ThiSinhData(anhUploads, thiSinh,userId);
            /*var result = await _http.PutAsJsonAsync($"api/thisinh/{thiSinh.Id}", thiSinhData);*/
            using (var content = new StringContent(JsonConvert.SerializeObject(thiSinhData), System.Text.Encoding.UTF8, "application/json"))
            {
                var result = await _http.PutAsync($"api/thisinh/{thiSinh.Id}", content);
                await SetThiSinhssr(result);
            }
        }

        public async Task GetChartData()
        {
            var result = await _http.GetFromJsonAsync<double[]>("api/thisinh/data");
            if (result != null)
                data = result;

        }
    }
}
