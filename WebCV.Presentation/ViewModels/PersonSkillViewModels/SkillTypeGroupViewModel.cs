namespace WebCV.Presentation.ViewModels.PersonSkillViewModels
{
    public class SkillTypeGroupViewModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public List<SkillGroupViewModel> Groups { get; set; }
    }
}
