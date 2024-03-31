using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.Configuration;

public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");
        builder.ToTable("Cars").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").HasColumnType("nvarchar(150)").IsRequired();
        builder.Property(c => c.Model).HasColumnName("Model").HasColumnType("nvarchar(150)").IsRequired();
        builder.Property(c => c.EnginePower).HasColumnName("EnginePower").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
       // builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        //builder.HasOne(c => c.Model);

        //builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
