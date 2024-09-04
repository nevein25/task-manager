using MediatR;

namespace ToDo.Application.ToDoItems.Commands.DeleteToDoItem;
public class DeleteToDoItemCommand : IRequest
{
    public int Id { get; }
    public DeleteToDoItemCommand(int id)
    {
        Id = id;
    }
}
