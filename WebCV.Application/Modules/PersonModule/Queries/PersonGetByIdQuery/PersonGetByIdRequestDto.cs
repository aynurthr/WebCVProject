using WebCV.Domain.Models.Stables;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace WebCV.Application.Modules.PersonModule.Queries.PersonGetByIdQuery
{
    public class PersonGetByIdRequestDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public byte Experience { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public Degrees Degree { get; set; }
        public string Bio { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }
        public string AttachmentUrl { get; set; }
        public CareerLevels CareerLevel { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

