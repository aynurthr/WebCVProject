using WebCV.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery
{
    class PersonSkillGetAllRequestHandler : IRequestHandler<PersonSkillGetAllRequest, IEnumerable<PersonSkillGetAllRequestDto>>
    {
        private readonly IPersonSkillRepository personSkillRepository;
        private readonly ISkillRepository skillRepository;


        public PersonSkillGetAllRequestHandler(IPersonSkillRepository personSkillRepository, ISkillRepository skillRepository)
        {
            this.personSkillRepository = personSkillRepository;
            this.skillRepository = skillRepository;
        }

        public async Task<IEnumerable<PersonSkillGetAllRequestDto>> Handle(PersonSkillGetAllRequest request, CancellationToken cancellationToken)
        {

            var dto = await (
                from ps in personSkillRepository.GetAll(m => m.DeletedAt == null)
                join s in skillRepository.GetAll() on ps.SkillId equals s.Id
                where ps.PersonId == 1
                select new PersonSkillGetAllRequestDto
                {
                    PersonId = ps.PersonId,
                    SkillId = s.Id,
                    SkillName = s.Name,
                    Mode = ps.Mode,
                    Percentage = ps.Percentage
                }
            ).ToListAsync(cancellationToken);

            return dto;
        }

    }
}
