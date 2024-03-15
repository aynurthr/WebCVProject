using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class ContactPost
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Answer { get; set; }
        public DateTime? AnsweredAt { get; set; }
        public int? AnsweredBy { get; set; }
    }
}
