using WebCV.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCV.DataAccessLayer.Configurations
{
    class BlogPostEntityTypeConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Body).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.Property(m => m.PublishedBy).HasColumnType("int");
            builder.Property(m => m.PublishedAt).HasColumnType("datetime");

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("BlogPosts");
        }
    }
    
}
