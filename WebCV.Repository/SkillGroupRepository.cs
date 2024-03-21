using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class SkillGroupRepository : AsyncRepository<SkillGroup>, ISkillGroupRepository
    {
        public SkillGroupRepository(DbContext db) : base(db)
        {
        }
    }
}
