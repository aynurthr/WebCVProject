﻿using WebCV.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCV.DataAccessLayer.Configurations
{
    class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.FullName).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Experience).HasColumnType("tinyint").IsRequired();
            builder.Property(m => m.DateOfBirth).HasColumnType("datetime").IsRequired();
            builder.Property(m => m.Location).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Degree).HasColumnType("int").IsRequired();
            builder.Property(m => m.Bio).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Fax).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(m => m.Website).HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.AttachmentPath).HasColumnType("varchar").HasMaxLength(100).IsRequired(); ;
            builder.Property(m => m.CareerLevel).HasColumnType("int").IsRequired();
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();


            builder.Property(m => m.Phone).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();


        builder.HasKey(m => m.Id);
            builder.ToTable("People");
        }
    }
    
}
