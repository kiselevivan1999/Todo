using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.EntityFramework.Context;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) 
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
