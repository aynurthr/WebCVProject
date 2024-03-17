using WebCV.Domain.Models.Entities;
using MediatR;

namespace WebCV.Application.Modules.PersonModule.Queries.PersonGetAllQuery
{
    public class PersonGetAllRequest : IRequest<IEnumerable<Person>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
