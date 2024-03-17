using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class ServiceRepository : AsyncRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DbContext db) : base(db)
        {
        }
    }
}
