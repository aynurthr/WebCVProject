using WebCV.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCV.DataAccessLayer.Configurations
{
    class SkillGroupEntityTypeConfiguration : IEntityTypeConfiguration<SkillGroup>
    {
        public void Configure(EntityTypeBuilder<SkillGroup> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.TypeId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("SkillGroups");

            builder.HasOne<SkillType>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.TypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    
}
