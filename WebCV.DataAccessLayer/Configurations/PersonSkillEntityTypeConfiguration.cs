using WebCV.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebCV.DataAccessLayer.Configurations
{
    class PersonSkillEntityTypeConfiguration : IEntityTypeConfiguration<PersonSkill>
    {
        public void Configure(EntityTypeBuilder<PersonSkill> builder)
        {
            builder.Property(m => m.PersonId).HasColumnType("int");
            builder.Property(m => m.SkillId).HasColumnType("int");
            builder.Property(m => m.Mode).HasColumnType("int").IsRequired();
            builder.Property(m => m.Percentage).HasColumnType("tinyint");


            builder.HasKey(m => new { m.PersonId, m.SkillId });
            builder.ConfigureAuditable();
            builder.ToTable("PersonSkills");


            builder.HasOne<Person>()
                            .WithMany()
                            .HasPrincipalKey(m => m.Id)
                            .HasForeignKey(m => m.PersonId)
                            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Skill>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.SkillId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    
}
