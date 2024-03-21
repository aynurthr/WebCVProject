using WebCV.Domain.Models.Stables;

namespace WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery;
    public class PersonSkillGetAllRequestDto
    {
        public int PersonId { get; set; } 
        public int SkillId { get; set; }
        public string SkillName { get; set; } 
        public DisplayMode Mode { get; set; }
        public int Percentage { get; set; }

}
