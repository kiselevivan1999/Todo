using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.EntityFramework.Configurations;

internal class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(x => x.Title)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(x => x.Description)
            .HasMaxLength(1000);
        builder.Property(x => x.Priority);
    }
}
