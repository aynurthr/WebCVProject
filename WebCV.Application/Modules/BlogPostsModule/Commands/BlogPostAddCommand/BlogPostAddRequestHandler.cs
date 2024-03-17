using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Abstracts;
using MediatR;

namespace WebCV.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand
{
    class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPostAddRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostAddRequestHandler(
            IBlogPostRepository blogPostRepository, 
            IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }

        public async Task<BlogPostAddRequestDto> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new BlogPost
            {
                Title = request.Title,
                Body = request.Body,
            };

            entity.ImagePath = await fileService.UploadAsync(request.Image);

            await blogPostRepository.AddAsync(entity,cancellationToken);
            await blogPostRepository.SaveAsync(cancellationToken);

            var dto = new BlogPostAddRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Body = entity.Body,
                ImageUrl = entity.ImagePath
            };

            #warning must be complete

            return dto;
        }
    }
}
