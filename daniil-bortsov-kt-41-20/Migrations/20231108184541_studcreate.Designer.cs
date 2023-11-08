﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using daniil_bortsov_kt_41_20.Database;

#nullable disable

namespace daniil_bortsov_kt_41_20.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20231108184541_studcreate")]
    partial class studcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("daniil_bortsov_kt_41_20.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("grade_id")
                        .HasComment("Идентификатор оценки");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<int>("Mark")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("mark")
                        .HasComment("Оценка");

                    b.Property<int>("StudentId")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("stud_id")
                        .HasComment("Идентификатор студента");

                    b.Property<int>("SubjectId")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("subject_id")
                        .HasComment("Идентификатор предмета");

                    b.HasKey("GradeId")
                        .HasName("pk_(TableName) grade_id");

                    b.HasIndex(new[] { "StudentId" }, "idx_Grades_fk_f_stud_id");

                    b.HasIndex(new[] { "SubjectId" }, "idx_Grades_fk_f_subject_id");

                    b.ToTable("Grades", (string)null);
                });

            modelBuilder.Entity("daniil_bortsov_kt_41_20.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_id")
                        .HasComment("Идентификатор группы");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("group_name")
                        .HasComment("Название группы");

                    b.HasKey("GroupId")
                        .HasName("pk_(TableName) group_id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("daniil_bortsov_kt_41_20.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("stud_id")
                        .HasComment("Идентификатор студента");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("GroupId")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("group_id")
                        .HasComment("Идентификатор группы");

                    b.Property<string>("StudentMidname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("stud_midname")
                        .HasComment("Отчество студента");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("stud_name")
                        .HasComment("Имя студента");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("stud_surname")
                        .HasComment("Фамилия студента");

                    b.HasKey("StudentId")
                        .HasName("pk_(TableName) stud_id");

                    b.HasIndex(new[] { "GroupId" }, "idx_Students_fk_f_group_id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("daniil_bortsov_kt_41_20.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_id")
                        .HasComment("Идентификатор предмета");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("subject_name")
                        .HasComment("Название предмета");

                    b.HasKey("SubjectId")
                        .HasName("pk_(TableName) subject_id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("daniil_bortsov_kt_41_20.Models.Grade", b =>
                {
                    b.HasOne("daniil_bortsov_kt_41_20.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_stud_id");

                    b.HasOne("daniil_bortsov_kt_41_20.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_subject_id");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("daniil_bortsov_kt_41_20.Models.Student", b =>
                {
                    b.HasOne("daniil_bortsov_kt_41_20.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
