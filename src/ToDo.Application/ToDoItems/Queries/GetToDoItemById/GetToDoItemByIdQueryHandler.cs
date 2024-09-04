using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ToDo.Application.ToDoItems.DTOs;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.ToDoItems.Queries.GetToDoItemById;

public class GetToDoItemByIdQueryHandler : IRequestHandler<GetToDoItemByIdQuery, ToDoItemDto?>
{
    private readonly IToDoItemsRepository _toDoItemsRepository;
    private readonly IMapper _mapper;

    public GetToDoItemByIdQueryHandler(IToDoItemsRepository toDoItemsRepository,
                                   IMapper mapper,
                                   ILogger<GetToDoItemByIdQueryHandler> logger)
    {
        _toDoItemsRepository = toDoItemsRepository;
        _mapper = mapper;
    }
    public async Task<ToDoItemDto?> Handle(GetToDoItemByIdQuery? request, CancellationToken cancellationToken)
    {
        if (request == null) return null;

        var item = await _toDoItemsRepository.GetByIdAsync(request.Id) 
                        ?? throw new NotFoundException(nameof(ToDoItem), request.Id.ToString()); ;
        var itemDto = _mapper.Map<ToDoItemDto?>(item);

        return itemDto;
    }
}
