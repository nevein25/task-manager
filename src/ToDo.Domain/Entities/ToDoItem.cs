namespace ToDo.Domain.Entities;
public class ToDoItem
{

    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public bool Completed { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = default!;
    public int UserId { get; set; }

}
