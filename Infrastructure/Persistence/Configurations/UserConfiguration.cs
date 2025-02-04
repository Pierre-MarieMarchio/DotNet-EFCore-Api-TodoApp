using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Models;

namespace TodoApi.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("Username");

        builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email");
        builder.HasIndex(u => u.Email)
                .IsUnique();

        builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password");

        builder.HasMany(u => u.TodoItems)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

    }
}
