using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebCV.Application.Repositories;

namespace WebCV.Application.Modules.PersonModule.Queries.PersonGetByIdQuery
{
    class PersonGetByIdRequestHandler : IRequestHandler<PersonGetByIdRequest, PersonGetByIdRequestDto>
    {
        private readonly IPersonRepository personRepository;
        private readonly IActionContextAccessor ctx;
        public PersonGetByIdRequestHandler(IPersonRepository personRepository, IActionContextAccessor ctx)
        {
            this.personRepository = personRepository;
            this.ctx = ctx;
        }

        public async Task<PersonGetByIdRequestDto> Handle(PersonGetByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await personRepository.GetAsync(m => m.Id == 1, cancellationToken);

            string host = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}";

            return new PersonGetByIdRequestDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Experience = entity.Experience,
                DateOfBirth = entity.DateOfBirth,
                Location = entity.Location,
                Degree = entity.Degree,
                Bio = entity.Bio,
                Fax = entity.Fax,
                Website = entity.Website,

                Phone = entity.Phone,
                Email = entity.Email,


                AttachmentUrl = $"{host}/uploads/files/{entity.AttachmentPath}",
                CareerLevel = entity.CareerLevel,
            };
        }
    }
}

