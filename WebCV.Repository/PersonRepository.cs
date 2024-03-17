using WebCV.Application.Repositories;
using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Concrates;
using Microsoft.EntityFrameworkCore;

namespace WebCV.Repository
{
    class PersonRepository : AsyncRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext db) : base(db)
        {
        }
    }
}
