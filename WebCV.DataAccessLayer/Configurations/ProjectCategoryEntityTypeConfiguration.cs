using WebCV.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCV.DataAccessLayer.Configurations
{
    class ProjectCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            builder.Property(m => m.ProjectId).HasColumnType("int");
            builder.Property(m => m.CategoryId).HasColumnType("int");

            builder.HasKey(m => new { m.ProjectId, m.CategoryId});

            builder.ToTable("ProjectCategories");

            builder.HasOne<Category>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Project>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    
}
