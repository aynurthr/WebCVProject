using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class CategoryRepository : AsyncRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext db) : base(db)
        {
        }
    }
}
