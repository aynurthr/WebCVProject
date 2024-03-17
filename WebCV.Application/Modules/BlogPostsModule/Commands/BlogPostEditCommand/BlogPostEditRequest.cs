using MediatR;
using Microsoft.AspNetCore.Http;

namespace WebCV.Application.Modules.BlogPostsModule.Commands.BlogPostEditCommand
{
    public class BlogPostEditRequest : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IFormFile Image { get; set; }
    }
}

