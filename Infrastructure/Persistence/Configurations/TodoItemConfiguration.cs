using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Models;

namespace TodoApi.Infrastructure.Persistence.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Title");

        builder.Property(t => t.IsComplete)
                .IsRequired()
                .HasColumnName("IsComplete");

        builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId");

        builder.HasOne(t => t.User)
                .WithMany(u => u.TodoItems)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.TodoItemTags)
                .WithMany(tt => tt.TodoItems)
                .UsingEntity(j => j.ToTable("TodoItemTodoItemTags"));
    }
}