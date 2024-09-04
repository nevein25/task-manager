using MediatR;

namespace ToDo.Application.ToDoItems.Commands.CreateToDoItem;
public class CreateToDoItemCommand : IRequest<int>
{
    public string Title { get; set; } = default!;
    public bool Completed { get; set; }
}
