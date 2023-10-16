namespace EntityFrameworkCoreApiSamples.Models;

public class Todo
{
    public Todo()
    {
        TodoItems = new HashSet<TodoItem>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<TodoItem> TodoItems { get; set; }
}
