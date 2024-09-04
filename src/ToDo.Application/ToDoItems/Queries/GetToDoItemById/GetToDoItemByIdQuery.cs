using MediatR;
using ToDo.Application.ToDoItems.DTOs;

namespace ToDo.Application.ToDoItems.Queries.GetToDoItemById;
public class GetToDoItemByIdQuery : IRequest<ToDoItemDto?>
{

    public int Id { get;}
    public GetToDoItemByIdQuery(int id)
    {
        Id = id;
    }
}
