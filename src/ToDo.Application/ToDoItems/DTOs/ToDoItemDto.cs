namespace ToDo.Application.ToDoItems.DTOs;
public class ToDoItemDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public bool Completed { get; set; } = false;

    public DateTime CreatedAt { get; set; } 

    public int UserId { get; set; }
    public string Username { get; set; } = default!;

}
