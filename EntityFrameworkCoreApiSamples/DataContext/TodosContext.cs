using EntityFrameworkCoreApiSamples.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreApiSamples.DataContext
{
    public class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions<TodosContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(builder =>
            {
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Id)
                       .ValueGeneratedOnAdd();

                builder.Property(t => t.Name)
                       .HasColumnName("todo_name")
                       .IsRequired();

                builder.HasMany(t => t.TodoItems)
                       .WithOne(t => t.Todo)
                       .HasForeignKey(t => t.TodoId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasData(
                    new Todo
                    {
                        Id = 1,
                        Name = "Project management",
                    });
            });

            modelBuilder.Entity<TodoItem>(builder =>
            {
                builder.HasData(
                  new TodoItem { Id = 1, Description = "Create a Database Context", IsCompleted = false, TodoId = 1 },
                  new TodoItem { Id = 2, Description = "Create Todo entity", IsCompleted = false, TodoId = 1 },
                  new TodoItem { Id = 3, Description = "Create TodoItem entity", IsCompleted = false, TodoId = 1 }
                );
            });
        }
    }
}
