using MediatR;


namespace ToDo.Application.ToDoItems.Commands.UpdateToDoItem;
public class UpdateToDoItemCommand : IRequest
{
    public int Id { get; set; }

    public string Title { get; set; } = default!;
    public bool Completed { get; set; } 
}
