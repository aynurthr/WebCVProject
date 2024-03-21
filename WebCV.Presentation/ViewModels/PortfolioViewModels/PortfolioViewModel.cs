namespace WebCV.Presentation.ViewModels.PortfolioViewModels
{
    public class PortfolioViewModel
    {
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }

    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
        public string CategoriesClass { get; set; }
    }
}
