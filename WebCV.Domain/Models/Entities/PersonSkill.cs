using System;
using WebCV.Domain.Models.Stables;
using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class PersonSkill : AuditableEntity
    {
        public int PersonId { get; set; }
        public int SkillId { get; set; }
        public DisplayMode Mode { get; set; }
        public byte Percentage { get; set; }
    }
}
