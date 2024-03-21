using MediatR;

namespace WebCV.Application.Modules.ProjectCategoriesModule.Queries.ProjectCategoryGetAllQuery
{
    public class ProjectCategoryGetAllRequest : IRequest<IEnumerable<ProjectCategoryGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
