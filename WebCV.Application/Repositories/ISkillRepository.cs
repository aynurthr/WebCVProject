﻿using WebCV.Domain.Models.Entities;
using WebCV.Infrastructure.Abstracts;

namespace WebCV.Application.Repositories
{
    public interface ISkillRepository : IAsyncRepository<Skill>
    {
    }
}