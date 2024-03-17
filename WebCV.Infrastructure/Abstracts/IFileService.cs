using Microsoft.AspNetCore.Http;

namespace WebCV.Infrastructure.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadAsyncImage(IFormFile file);
        Task<string> ChangeFileAsyncImage(string oldFilePath, IFormFile file);
        Task<string> UploadAsyncFile(IFormFile file);
        Task<string> ChangeFileAsyncFile(string oldFilePath, IFormFile file);

    }
}
