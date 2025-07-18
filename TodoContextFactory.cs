using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ToDoApi.Data;

public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
{
    public TodoContext CreateDbContext(string[] args)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new TodoContext(optionsBuilder.Options);
    }
}
