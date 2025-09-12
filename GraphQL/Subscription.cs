using HotChocolate; // For [Subscribe], [Topic], [EventMessage]
using HotChocolate.Subscriptions;
using SocketDemoProject.Models;

using Task = SocketDemoProject.Models.Task;

namespace SocketDemoProject.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic(nameof(OnTaskCreated))]
        public Task OnTaskCreated([EventMessage] Task task) => task;

        [Subscribe]
        [Topic(nameof(OnTaskStatusUpdated))]
        public Task OnTaskStatusUpdated([EventMessage] Task task) => task;
    }
}