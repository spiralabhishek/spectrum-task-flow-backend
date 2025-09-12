using SocketDemoProject.Data;
using SocketDemoProject.Models;
using HotChocolate.Subscriptions;
using HotChocolate.Data; 
using HotChocolate; 

using Task = SocketDemoProject.Models.Task;
using ModelsTaskStatus = SocketDemoProject.Models.TaskStatus; 

namespace SocketDemoProject.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async System.Threading.Tasks.Task<Task> CreateTask(
            string title,
            string description,
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender)
        {
            var newTask = new Task
            {
                Title = title,
                Description = description,
                Status = ModelsTaskStatus.Pending // Using the alias
            };

            context.Tasks.Add(newTask);
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnTaskCreated), newTask);
            return newTask;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async System.Threading.Tasks.Task<Task> UpdateTaskStatus(
            int id,
            ModelsTaskStatus status, // Using the alias for parameter type
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender)
        {
            var taskToUpdate = await context.Tasks.FindAsync(id);
            if (taskToUpdate == null)
            {
                throw new ArgumentException("Task not found.");
            }

            taskToUpdate.Status = status;
            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnTaskStatusUpdated), taskToUpdate);
            return taskToUpdate;
        }
    }
}