using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class Service : AuditableEntity
    {
        public int Id { get; set; }
        public string CssClass { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
     
    }
}
