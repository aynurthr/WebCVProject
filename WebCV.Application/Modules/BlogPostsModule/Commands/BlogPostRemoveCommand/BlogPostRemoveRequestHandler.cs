using WebCV.Application.Repositories;
using MediatR;

namespace WebCV.Application.Modules.BlogPostsModule.Commands.BlogPostRemoveCommand
{
    class BlogPostRemoveRequestHandler : IRequestHandler<BlogPostRemoveRequest>
    {
        private readonly IBlogPostRepository blogPostRepository;
        public BlogPostRemoveRequestHandler(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task Handle(BlogPostRemoveRequest request, CancellationToken cancellationToken)
        {

            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);

            blogPostRepository.Remove(entity);

            await blogPostRepository.SaveAsync(cancellationToken);
        }

    }
}
