namespace WebCV.Application.Modules.ProjectCategoriesModule.Queries.ProjectCategoryGetAllQuery;
    public class ProjectCategoryGetAllRequestDto
{
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
}
