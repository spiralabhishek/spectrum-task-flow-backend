# GraphQL Kanban Board - Backend

This is the backend server for the Kanban Board application, built with ASP.NET Core and Hot Chocolate. It provides a real-time GraphQL API for creating, updating, and fetching tasks.

## Features

-   **GraphQL API**: Exposes queries, mutations, and subscriptions for comprehensive task management.
-   **Real-time Updates**: Uses WebSockets and GraphQL Subscriptions to push live data changes to connected clients.
-   **In-Memory Database**: Utilizes Entity Framework Core's in-memory provider for a simple, zero-configuration setup.
-   **Filtering & Sorting**: Leverages Hot Chocolate's data integrations for powerful data retrieval.

## Technology Stack

-   .NET 8
-   ASP.NET Core
-   **GraphQL Server**: Hot Chocolate 13
-   **Database**: Entity Framework Core 8 (In-Memory Provider)

## Prerequisites

-   [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later.
-   A code editor like Visual Studio Code or Visual Studio 2022.

## Getting Started

Follow these steps to get the backend server up and running on your local machine.

1.  **Clone the repository**
    ```bash
    git clone <your-repository-url>
    cd <path-to-backend-folder>
    ```

2.  **Restore Dependencies**
    This command downloads and installs all the necessary NuGet packages defined in the `.csproj` file.
    ```bash
    dotnet restore
    ```

3.  **Run the Application**
    This command builds and starts the web server.
    ```bash
    dotnet run
    ```

4.  **Access the GraphQL IDE**
    The server will now be running, typically on a port like `7225`. Open your web browser and navigate to the `/graphql` endpoint to access the **Banana Cake Pop** IDE.
    -   **URL**: `https://localhost:7225/graphql` (replace `7225` with the port number shown in your terminal).

## Project Structure

```
/
├── Data/
│   └── AppDbContext.cs       # EF Core database context and data seeding.
├── GraphQL/
│   ├── Query.cs              # Defines GraphQL queries (e.g., getAllTasks).
│   ├── Mutation.cs           # Defines GraphQL mutations (e.g., createTask).
│   └── Subscription.cs       # Defines GraphQL subscriptions for real-time events.
├── Models/
│   └── Task.cs               # C# models and enums for the application.
├── Program.cs                # Main application entry point, service configuration (CORS, GraphQL).
└── SocketDemoProject.csproj  # Project file with all dependencies.
```

## API Schema Overview

-   **Queries**
    -   `getAllTasks`: Fetches all tasks. Supports filtering and sorting.
-   **Mutations**
    -   `createTask(title: String!, description: String!)`: Creates a new task.
    -   `updateTaskStatus(id: Int!, status: TaskStatus!)`: Updates the status of an existing task.
-   **Subscriptions**
    -   `onTaskCreated`: Pushes a notification when a new task is created.
    -   `onTaskStatusUpdated`: Pushes a notification when a task's status is updated.

---