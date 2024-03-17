﻿using System;
using WebCV.Infrastructure.Concrates;

namespace WebCV.Domain.Models.Entities
{
    public class BlogPost : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImagePath { get; set; }
        public int? PublishedBy { get; set; }
        public DateTime? PublishedAt { get; set; }

    }
}
