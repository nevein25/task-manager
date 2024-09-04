using AutoMapper;

using MediatR;
using Microsoft.Extensions.Logging;
using ToDo.Application.Users;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;

namespace ToDo.Application.ToDoItems.Commands.DeleteToDoItem;
public class DeleteToDoItemCommandHandler : IRequestHandler<DeleteToDoItemCommand>
{
    private readonly IToDoItemsRepository _toDoItemsRepository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;
    private readonly ILogger<DeleteToDoItemCommandHandler> _logger;

    public DeleteToDoItemCommandHandler(IToDoItemsRepository toDoItemsRepository,
                                    IMapper mapper,
                                    IUserContext userContext,
                                    ILogger<DeleteToDoItemCommandHandler> logger)
    {
        _toDoItemsRepository = toDoItemsRepository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _toDoItemsRepository.GetByIdAsync(request.Id);
        if (item is null)
            throw new NotFoundException(nameof(ToDoItem), request.Id.ToString());

        int? loggedInUserId = _userContext.UserId;
        if (loggedInUserId != item.UserId) throw new ForbidException("You can not delete post you do not own");

        await _toDoItemsRepository.Delete(item);
    }
}
