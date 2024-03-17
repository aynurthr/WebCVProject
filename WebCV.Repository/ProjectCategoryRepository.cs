using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class ProjectCategoryRepository : AsyncRepository<ProjectCategory>, IProjectCategoryRepository
    {
        public ProjectCategoryRepository(DbContext db) : base(db)
        {
        }
    }
}
