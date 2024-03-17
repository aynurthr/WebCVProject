using System;
using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class Skill : AuditableEntity
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }

    }
}
