using System;
using System.Drawing;

namespace QuanLyTuyenSinh.Server.Service.HinhAnhService
{
    public class HinhAnhService : IHinhAnhService
    {
        public static IWebHostEnvironment _environment;
        public HinhAnhService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public bool DeleteFile(string filePath)
        {
            if(File.Exists(_environment.WebRootPath + "\\uploads\\" +filePath))
            {
                File.Delete(_environment.WebRootPath + "\\uploads\\"+filePath);
                return true;
            }
            return false;
        }

        //public async Task<string> UploadFile(IFormFile file)
        //{

        //    try
        //    {
        //        FileInfo fileinfo = new(file.FileName);
        //        var folderdirectory = $"{_environment.WebRootPath}\\uploads";
        //        if (!Directory.Exists(folderdirectory))
        //        {
        //            Directory.CreateDirectory(folderdirectory);
        //        }
        //        var filepath = Path.Combine(folderdirectory, file.FileName);
        //        await using FileStream fs = new FileStream(filepath, FileMode.Create);
        //        await file.OpenReadStream().CopyToAsync(fs);

        //        var fullpath = $"{file.FileName}";
        //        return fullpath;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}

         public async Task<string> UploadFile(string img)
        {
            try
            {
                var directory = $"{_environment.WebRootPath}\\uploads";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                var data = img.Substring(0, 5);
                var extension = Extension(data);
                var imageName = string.Format(@"{0}", Guid.NewGuid()) + extension;

                string imgPath =Path.Combine(directory,imageName);
                var imageByte = Convert.FromBase64String(img);
                var imageFile = new FileStream(imgPath, FileMode.Create);
                imageFile.Write(imageByte,0,imageByte.Length);
                imageFile.Flush();

                return imageName;
            }catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Extension(string image)
        {
            var extension = "";
            switch (image.ToUpper())
            {
                case "IVBOR":
                    return extension = ".png";
                case "/9J/4":
                    return extension = ".jpg";
            }
            return extension;
        }

    }
}
