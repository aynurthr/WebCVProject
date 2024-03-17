using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class PersonSkillRepository : AsyncRepository<PersonSkill>, IPersonSkillRepository
    {
        public PersonSkillRepository(DbContext db) : base(db)
        {
        }
    }
}
