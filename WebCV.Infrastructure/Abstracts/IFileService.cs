using Microsoft.AspNetCore.Http;

namespace WebCV.Infrastructure.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file);
        Task<string> ChangeFileAsync(string oldFilePath, IFormFile file);

    }
}
