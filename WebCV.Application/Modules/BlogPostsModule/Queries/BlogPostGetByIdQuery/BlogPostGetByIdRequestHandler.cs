using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebCV.Application.Repositories;

namespace WebCV.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery
{
    public class BlogPostGetByIdRequestHandler : IRequestHandler<BlogPostGetByIdRequest, BlogPostGetByIdRequestDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IActionContextAccessor ctx;

        public BlogPostGetByIdRequestHandler(IBlogPostRepository blogPostRepository, IActionContextAccessor ctx)
        {
            this.blogPostRepository = blogPostRepository;
            this.ctx = ctx;
        }

        public async Task<BlogPostGetByIdRequestDto> Handle(BlogPostGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            return new BlogPostGetByIdRequestDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Body = entity.Body,
                ImageUrl = $"{host}/uploads/images/{entity.ImagePath}",
                PublishedAt = entity.PublishedAt
            };
        }

    }
}

