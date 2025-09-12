using HotChocolate.Types;
using SocketDemoProject.Models;

using Task = SocketDemoProject.Models.Task;
using ModelsTaskStatus = SocketDemoProject.Models.TaskStatus; 

namespace SocketDemoProject.GraphQL
{
    public class TaskType : ObjectType<Task>
    {
        protected override void Configure(IObjectTypeDescriptor<Task> descriptor)
        {
            descriptor.Description("Represents a task item.");

            descriptor.Field(t => t.Id)
                .Description("The unique identifier of the task.");

            descriptor.Field(t => t.Title)
                .Description("The title of the task.");

            descriptor.Field(t => t.Description)
                .Description("The detailed description of the task.");

            descriptor.Field(t => t.Status)
                .Description("The current status of the task (Pending or Completed).");
            // No direct TaskStatus reference here, but good to have the alias if needed elsewhere.
        }
    }
}