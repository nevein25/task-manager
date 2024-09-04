using AutoMapper;

using MediatR;
using ToDo.Application.Common;
using ToDo.Application.ToDoItems.DTOs;
using ToDo.Application.Users;
using ToDo.Domain.Repositories;

namespace ToDo.Application.ToDoItems.Queries.GetAllToDoItems;
public class GetAllToDoItemsQueryHandler : IRequestHandler<GetAllToDoItemsQuery, PagedResult<ToDoItemDto>>
{
    private readonly IToDoItemsRepository _toDoItemsRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public GetAllToDoItemsQueryHandler(IToDoItemsRepository toDoItemsRepository,
                                   IMapper mapper,
                                   IUserContext userContext)
    {
        _toDoItemsRepository = toDoItemsRepository;
        _mapper = mapper;
        _userContext = userContext;
    }


    public async Task<PagedResult<ToDoItemDto>> Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
    {
        var loggedInUserId = _userContext.UserId;
        if (loggedInUserId == null) throw new InvalidOperationException("User Id is not available.");


        var (items, totalCount) = await _toDoItemsRepository.GetMatchingItems(loggedInUserId, request.SearchPhraseTitle,
                                                                                    request.PageSize, request.PageNumber,
                                                                                    request.SortBy, request.SortDirection);

        var itemsDto = _mapper.Map<IEnumerable<ToDoItemDto>>(items);

        var result = new PagedResult<ToDoItemDto>(itemsDto, totalCount, request.PageSize, request.PageNumber);
        return result;
    }
}
