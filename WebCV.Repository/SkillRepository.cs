using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class SkillRepository : AsyncRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DbContext db) : base(db)
        {
        }
    }
}
