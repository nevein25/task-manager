using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDo.Domain.Constants;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Persistance;

namespace ToDo.Infrastructure.Repositories;

internal class ToDoItemsRepository : IToDoItemsRepository
{
    private readonly ToDoManagerDbContext _context;

    public ToDoItemsRepository(ToDoManagerDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(ToDoItem item)
    {
        _context.ToDoItems.Add(item);
        await _context.SaveChangesAsync();
        return item.Id;
    }

    public async Task<IEnumerable<ToDoItem>> GetAll()
    {
        return await _context.ToDoItems.Include(p => p.User).ToListAsync();
    }

    public async Task<(IEnumerable<ToDoItem>, int)> GetMatchingItems(int? userId,
                                                                         string? searchPhraseTitle,
                                                                         int pageSize,
                                                                         int pageNumber,
                                                                         string? sortBy,
                                                                         SortDirection sortDirection)
    {
        var searchPhraseTitleUpper = searchPhraseTitle?.ToUpper();

        var baseQuery = _context.ToDoItems
                              .Include(i => i.User)
                              .Where(
                                 u => u.UserId == userId &&
                                 (searchPhraseTitleUpper == null || u.Title.ToUpper().Contains(searchPhraseTitleUpper)));



        var totalCount = await baseQuery.CountAsync();

        if (sortBy != null)
        {
            var columnsSelector = new Dictionary<string, Expression<Func<ToDoItem, object>>>
            {
                { nameof(ToDoItem.CreatedAt), p => p.CreatedAt },
                { nameof(ToDoItem.Title), p => p.Title }
            };

            var selectedColumn = columnsSelector[sortBy];

            baseQuery = sortDirection == SortDirection.Ascending
                                    ? baseQuery.OrderBy(selectedColumn)
                                    : baseQuery.OrderByDescending(selectedColumn);
        }

        var items = await baseQuery
                                .Skip(pageSize * (pageNumber - 1))
                                .Take(pageSize)
                                .ToListAsync();

        return (items, totalCount);
    }

    public async Task<ToDoItem?> GetByIdAsync(int id)
    {
        var item = await _context.ToDoItems
            .Include(i => i.User)
            .FirstOrDefaultAsync(x => x.Id == id);
        return item;
    }

    public async Task Delete(ToDoItem entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
    public Task SaveChanges() => _context.SaveChangesAsync();


}

