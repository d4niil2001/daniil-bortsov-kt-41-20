using daniil_bortsov_kt_41_20.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using daniil_bortsov_kt_41_20.Models;

namespace daniil_bortsov_kt_41_20.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Models.Student>
    {
        private const string TableName = "Students";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                     .HasKey(p => p.StudentId)
                     .HasName($"pk_(TableName) stud_id");

            builder
                  .Property(p => p.StudentId)
                  .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
               .HasColumnName("stud_id")
               .HasComment("Идентификатор студента");

            builder.Property(p => p.StudentSurname)
                .IsRequired()
                .HasColumnName("stud_surname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.StudentName)
               .IsRequired()
               .HasColumnName("stud_name")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Имя студента");

            builder.Property(p => p.StudentMidname)
              .IsRequired()
              .HasColumnName("stud_midname")
              .HasColumnType(ColumnType.String).HasMaxLength(100)
              .HasComment("Отчество студента");

            builder.Property(p => p.GroupId)
               .IsRequired()
               .HasColumnName("group_id")
               .HasColumnType(ColumnType.Int).HasMaxLength(100)
               .HasComment("Идентификатор группы");

            builder.ToTable(TableName)
               .HasOne(p => p.Group)
               .WithMany()
               .HasForeignKey(p => p.GroupId)
               .HasConstraintName("fk_f_group_id")
               .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group)
                .AutoInclude();

        }

    }
}
