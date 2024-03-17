
namespace WebCV.Application.Modules.BlogPostsModule.Queries.BlogPostGetByIdQuery
{
    public class BlogPostGetByIdRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? PublishedAt { get; set; }

    }
}

