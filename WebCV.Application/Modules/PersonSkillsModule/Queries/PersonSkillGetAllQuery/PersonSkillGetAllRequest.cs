using MediatR;

namespace WebCV.Application.Modules.PersonSkillsModule.Queries.PersonSkillGetAllQuery
{
    public class PersonSkillGetAllRequest : IRequest<IEnumerable<PersonSkillGetAllRequestDto>>
    {
        public bool OnlyAvailable { get; set; } = true;
    }
}
