using WebCV.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCV.DataAccessLayer.Configurations
{
    class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Url).HasColumnType("varchar").HasMaxLength(300).IsRequired();


            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Projects");
        }
    }
}
