using ToDo.Application.ToDoItems.DTOs;

namespace ToDo.Application.Interfaces;
public interface ILiveToDoItemsService
{
    Task<IEnumerable<ToDoItemDto>> GetLiveToDoItemsAsync(int page, int pageSize);
}
