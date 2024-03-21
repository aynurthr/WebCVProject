using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebCV.Application.Repositories;

namespace WebCV.Application.Modules.ProjectCategoriesModule.Queries.ProjectCategoryGetAllQuery
{
    class ProjectCategoryGetAllRequestHandler : IRequestHandler<ProjectCategoryGetAllRequest, IEnumerable<ProjectCategoryGetAllRequestDto>>
    {
        private readonly IProjectCategoryRepository projectCategoryRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IActionContextAccessor ctx;


        public ProjectCategoryGetAllRequestHandler(IProjectCategoryRepository projectCategoryRepository, IActionContextAccessor ctx, IProjectRepository projectRepository, ICategoryRepository categoryRepository)
        {
            this.projectCategoryRepository = projectCategoryRepository;
            this.projectRepository = projectRepository;
            this.categoryRepository = categoryRepository;
            this.ctx = ctx;
        }

        public async Task<IEnumerable<ProjectCategoryGetAllRequestDto>> Handle(ProjectCategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            var dto = await (
             from pc in projectCategoryRepository.GetAll()
             join p in projectRepository.GetAll(m => m.DeletedAt == null) on pc.ProjectId equals p.Id
             join c in categoryRepository.GetAll(m => m.DeletedAt == null) on pc.CategoryId equals c.Id
             select new ProjectCategoryGetAllRequestDto
             {
                 ProjectId = p.Id,
                 ProjectName = p.Title,
                 ImagePath = $"{host}/uploads/images/{p.ImagePath}",
                 Url = p.Url,
                 CategoryId = c.Id,
                 CategoryName = c.Name
             }).ToListAsync(cancellationToken);

            return dto;
        }

    }
}
