using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccessLayer.EfMappings;
using ToDoList.DataAccessLayer.Entity;

namespace ToDoList.DataAccessLayer.ToDoContext
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }
        public DbSet<ToDo> ToDos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoMap());
        }
    }
}
