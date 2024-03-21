using WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery;

namespace WebCV.Presentation.ViewModels.PersonSkillViewModels
{
    public class SkillGroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public List<PersonSkillGetAllRequestDto> Skills { get; set; }
    }
}
