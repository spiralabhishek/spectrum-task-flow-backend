using Microsoft.EntityFrameworkCore;
using SocketDemoProject.Models;
using Task = SocketDemoProject.Models.Task;
using ModelsTaskStatus = SocketDemoProject.Models.TaskStatus;


namespace SocketDemoProject.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData( 
                new Task { Id = 1, Title = "Learn GraphQL", Description = "Study Hot Chocolate framework", Status = ModelsTaskStatus.Pending },
                new Task { Id = 2, Title = "Build Backend", Description = "Develop ASP.NET Core GraphQL API", Status = ModelsTaskStatus.Completed }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}