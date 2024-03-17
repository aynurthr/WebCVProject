using System;
using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class SkillType : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
