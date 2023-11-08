using daniil_bortsov_kt_41_20.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using daniil_bortsov_kt_41_20.Models;

namespace daniil_bortsov_kt_41_20.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Models.Group>
    {
        private const string TableName = "Groups";
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                     .HasKey(p => p.GroupId)
                     .HasName($"pk_(TableName) group_id");

            builder
                  .Property(p => p.GroupId)
                  .ValueGeneratedOnAdd();

            builder.Property(p => p.GroupId)
               .HasColumnName("group_id")
               .HasComment("Идентификатор группы");

            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("group_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название группы");
        }

        
    }
}
