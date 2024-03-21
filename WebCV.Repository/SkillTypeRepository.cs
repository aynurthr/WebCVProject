using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class SkillTypeRepository : AsyncRepository<SkillType>, ISkillTypeRepository
    {
        public SkillTypeRepository(DbContext db) : base(db)
        {
        }
    }
}
