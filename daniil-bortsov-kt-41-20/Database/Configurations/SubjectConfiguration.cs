using daniil_bortsov_kt_41_20.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using daniil_bortsov_kt_41_20.Models;

namespace daniil_bortsov_kt_41_20.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Models.Subject>
    {
        private const string TableName = "Subjects";
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder
                     .HasKey(p => p.SubjectId)
                     .HasName($"pk_(TableName) subject_id");

            builder
                  .Property(p => p.SubjectId)
                  .ValueGeneratedOnAdd();

            builder.Property(p => p.SubjectId)
               .HasColumnName("subject_id")
               .HasComment("Идентификатор предмета");

            builder.Property(p => p.SubjectName)
                .IsRequired()
                .HasColumnName("subject_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");
        }

    }
}
