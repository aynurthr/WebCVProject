using WebCV.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery
{
    class BlogPostGetAllRequestHandler : IRequestHandler<BlogPostGetAllRequest, IEnumerable<BlogPostGetAllRequestDto>>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IActionContextAccessor ctx;

        public BlogPostGetAllRequestHandler(IBlogPostRepository blogPostRepository, IActionContextAccessor ctx)
        {
            this.blogPostRepository = blogPostRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<BlogPostGetAllRequestDto>> Handle(BlogPostGetAllRequest request, CancellationToken cancellationToken)
        {
            var query = blogPostRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";
            var queryResponse = await query.Select(m => new BlogPostGetAllRequestDto
            {
                Id = m.Id,
                Title = m.Title,
                Body = m.Body,
                ImageUrl = $"{host}/uploads/images/{m.ImagePath}",
            }).ToListAsync(cancellationToken);

            return queryResponse;
        }

    }
}
