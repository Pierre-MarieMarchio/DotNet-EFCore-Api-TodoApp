using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Domain.Models;

namespace TodoApi.Infrastructure.Persistence.Configurations;

public class TodoItemTagConfiguration : IEntityTypeConfiguration<TodoItemTag>
{
    public void Configure(EntityTypeBuilder<TodoItemTag> builder)
    {
        builder.Property(t => t.TagName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("TagName");

        builder.HasMany(t => t.TodoItems)
                .WithMany(ti => ti.TodoItemTags)
                .UsingEntity(j => j.ToTable("TodoItemTodoItemTags"));
    }
}
