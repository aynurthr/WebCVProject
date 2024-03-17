using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class Project : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }

    }
}
