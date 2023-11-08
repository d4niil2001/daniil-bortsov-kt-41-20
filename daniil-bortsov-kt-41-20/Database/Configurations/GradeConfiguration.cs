using daniil_bortsov_kt_41_20.Models;
using daniil_bortsov_kt_41_20.Database.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace daniil_bortsov_kt_41_20.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Models.Grade>
    {
        private const string TableName = "Grades";
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder
                     .HasKey(p => p.GradeId)
                     .HasName($"pk_(TableName) grade_id");

            builder
                  .Property(p => p.GradeId)
                  .ValueGeneratedOnAdd();

            builder.Property(p => p.GradeId)
               .HasColumnName("grade_id")
               .HasComment("Идентификатор оценки");

            builder.Property(p => p.Mark)
                .IsRequired()
                .HasColumnName("mark")
                .HasColumnType(ColumnType.Int).HasMaxLength(100)
                .HasComment("Оценка");

            builder.Property(p => p.StudentId)
               .IsRequired()
               .HasColumnName("stud_id")
               .HasColumnType(ColumnType.Int).HasMaxLength(100)
               .HasComment("Идентификатор студента");

            builder.Property(p => p.SubjectId)
               .IsRequired()
               .HasColumnName("subject_id")
               .HasColumnType(ColumnType.Int).HasMaxLength(100)
               .HasComment("Идентификатор предмета");

            builder.ToTable(TableName)
               .HasOne(p => p.Student)
               .WithMany()
               .HasForeignKey(p => p.StudentId)
               .HasConstraintName("fk_f_stud_id")
               .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.StudentId, $"idx_{TableName}_fk_f_stud_id");

            builder.Navigation(p => p.Student)
                .AutoInclude();

            builder.ToTable(TableName)
              .HasOne(p => p.Subject)
              .WithMany()
              .HasForeignKey(p => p.SubjectId)
              .HasConstraintName("fk_f_subject_id")
              .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.SubjectId, $"idx_{TableName}_fk_f_subject_id");

            builder.Navigation(p => p.Subject)
                .AutoInclude();
        }

    }
}
