
using MediatR;
using ToDo.Application.Common;
using ToDo.Application.ToDoItems.DTOs;
using ToDo.Domain.Constants;

namespace ToDo.Application.ToDoItems.Queries.GetAllToDoItems;
public class GetAllToDoItemsQuery : IRequest<PagedResult<ToDoItemDto>>
{
    public string? SearchPhraseTitle { get; set; }
    public string? SearchPhraseAuthor { get; set; }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
