using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class ProjectRepository : AsyncRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext db) : base(db)
        {
        }
    }
}
