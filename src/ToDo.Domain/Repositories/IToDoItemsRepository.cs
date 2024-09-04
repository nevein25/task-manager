using ToDo.Domain.Constants;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Repositories;
public interface IToDoItemsRepository
{
    Task<int> Create(ToDoItem item);
    Task<IEnumerable<ToDoItem>> GetAll();
    Task<(IEnumerable<ToDoItem>, int)> GetMatchingItems(int? userId,
                                            string? searchPhraseTitle,
                                            int pageSize,
                                            int pageNumber,
                                            string? sortBy,
                                            SortDirection sortDirection);
    Task<ToDoItem?> GetByIdAsync(int id);
    Task Delete(ToDoItem item);
    Task SaveChanges();
}
