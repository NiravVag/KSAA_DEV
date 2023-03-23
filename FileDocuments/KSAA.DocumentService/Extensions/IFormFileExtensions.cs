using System.Net.Http.Headers;

namespace KSAA.DocumentService.Extensions
{
    public static class IFormFileExtensions
    {
        //const string rootFolder = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\KSAA_Files",);
        //const string rootFolder = "E:\\Development\\KSAA\\FileDocuments";
        //const string rootFolder = "C:\\KSAA_FileUpload";
        public static string GetFilename(this IFormFile file)
        {
            return ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
        }

        public static async Task<MemoryStream> GetFileStreamAsync(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream;
        }

        public static async Task<byte[]> GetFileArrayAsync(this IFormFile file)
        {
            MemoryStream filestream = new MemoryStream();
            await file.CopyToAsync(filestream);
            return filestream.ToArray();
        }

        public static async Task<string> SaveFileAsync(this IFormFile file)
        {
            bool IsfileCreated = false;
            var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot", "KSAA_Files",
                            CreateFileName("Test"));
            //var path = Path.Combine(
            //                rootFolder, "KSAA-Files",
            //                CreateFileName("Test-"));
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
                IsfileCreated = true;
            }

            if (IsfileCreated)
            {
                return path;
            }
            else
            {
                return string.Empty;
            }
        }

        private static string CreateFileName(string inputName)
        {
            return inputName + DateTime.Now.Ticks + ".xlsx";
        }
    }
}
