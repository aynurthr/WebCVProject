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
        private readonly ISkillGroupRepository skillGroupRepository;
        private readonly ISkillTypeRepository skillTypeRepository;


        public PersonSkillGetAllRequestHandler(IPersonSkillRepository personSkillRepository, ISkillRepository skillRepository, ISkillGroupRepository skillGroupRepository, ISkillTypeRepository skillTypeRepository)
        {
            this.personSkillRepository = personSkillRepository;
            this.skillRepository = skillRepository;
            this.skillGroupRepository = skillGroupRepository;
            this.skillTypeRepository = skillTypeRepository;
        }

        public async Task<IEnumerable<PersonSkillGetAllRequestDto>> Handle(PersonSkillGetAllRequest request, CancellationToken cancellationToken)
        {

            var dto = await (
                 from ps in personSkillRepository.GetAll(m => m.DeletedAt == null)
                 join s in skillRepository.GetAll() on ps.SkillId equals s.Id
                 join sg in skillGroupRepository.GetAll() on s.GroupId equals sg.Id
                 join st in skillTypeRepository.GetAll() on sg.TypeId equals st.Id
                 where ps.PersonId == 1
                 select new PersonSkillGetAllRequestDto
                 {
                     PersonId = ps.PersonId,
                     SkillId = s.Id,
                     SkillName = s.Name,
                     GroupId = sg.Id,
                     GroupName = sg.Name,
                     TypeId = st.Id,
                     TypeName = st.Name,
                     Mode = ps.Mode,
                     Percentage = ps.Percentage,
                     Bio = s.Bio
                 }
             ).ToListAsync(cancellationToken);


            return dto;
        }

    }
}
