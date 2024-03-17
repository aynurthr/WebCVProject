using MediatR;

namespace WebCV.Application.Modules.BlogPostsModule.Queries.BlogPostGetAllQuery
{
    public class BlogPostGetAllRequest : IRequest<IEnumerable<BlogPostGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
