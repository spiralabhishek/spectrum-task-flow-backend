using HotChocolate; 
using HotChocolate.Data;
using SocketDemoProject.Data;
using SocketDemoProject.Models;
using Task = SocketDemoProject.Models.Task;

namespace SocketDemoProject.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        [GraphQLName("getAllTasks")] 
        public IQueryable<Task> GetAllTasks([ScopedService] AppDbContext context)
        {
            return context.Tasks;
        }
    }
}