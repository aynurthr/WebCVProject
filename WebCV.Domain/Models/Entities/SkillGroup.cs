using System;
using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class SkillGroup : AuditableEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

    }
}
