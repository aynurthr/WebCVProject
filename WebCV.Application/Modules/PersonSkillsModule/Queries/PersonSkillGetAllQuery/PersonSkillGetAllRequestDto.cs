using WebCV.Domain.Models.Stables;

namespace WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery;
    public class PersonSkillGetAllRequestDto
    {
        public int PersonId { get; set; } 
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public DisplayMode Mode { get; set; }
        public byte? Percentage { get; set; }
        public string Bio { get; set; }

}
