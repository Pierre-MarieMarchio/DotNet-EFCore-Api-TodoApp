using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Commons;
using TodoApi.Shared.Extensions;

namespace TodoApi.Infrastructure.Commons;

public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseModel
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        var tableName = typeof(T).Name.Pluralize().ToSnakeCase();
        builder.ToTable(tableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
              .ValueGeneratedOnAdd()
              .HasDefaultValueSql("NEWID()");


       builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETDATE()")
               .ValueGeneratedOnAdd();

        builder.Property(x => x.UpdatedAt)
               .HasDefaultValueSql("GETDATE()")
               .ValueGeneratedOnAddOrUpdate();
    }
}
