using MediatR;

namespace WebCV.Application.Modules.PersonModule.Queries.PersonGetByIdQuery
{
    public class PersonGetByIdRequest : IRequest<PersonGetByIdRequestDto>
    {
        public int Id { get; set; }
    }
}

