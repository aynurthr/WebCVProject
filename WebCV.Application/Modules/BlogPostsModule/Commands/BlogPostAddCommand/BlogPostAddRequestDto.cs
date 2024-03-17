namespace WebCV.Application.Modules.BlogPostsModule.Commands.BlogPostAddCommand
{
    public class BlogPostAddRequestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Body { get; set; }

    }
}
