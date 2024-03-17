﻿using WebCV.Application.Repositories;
using WebCV.Infrastructure.Abstracts;
using MediatR;

namespace WebCV.Application.Modules.BlogPostsModule.Commands.BlogPostEditCommand
{
    class BlogPostEditRequestHandler : IRequestHandler<BlogPostEditRequest>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostEditRequestHandler(IBlogPostRepository blogPostRepository, IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }

        public async Task Handle(BlogPostEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await blogPostRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null);

            entity.Title = request.Title;
            entity.Body = request.Body;

            if (request.Image is not null)
            {
                entity.ImagePath = await fileService.ChangeFileAsync(entity.ImagePath, request.Image);
            }

            await blogPostRepository.SaveAsync(cancellationToken);

        }
    }
}

