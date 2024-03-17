using MediatR;

namespace WebCV.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery
{
    public class BlogPostGetByIdRequest : IRequest<BlogPostGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}
