

using AutoMapper;
using MediatR;
using ToDo.Application.Users;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
namespace ToDo.Application.ToDoItems.Commands.UpdateToDoItem;

public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand>
{
    private readonly IToDoItemsRepository _toDoItemsRepository;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public UpdateToDoItemCommandHandler(IToDoItemsRepository toDoItemsRepository,
                                    IUserContext userContext,
                                    IMapper mapper)
    {
        _toDoItemsRepository = toDoItemsRepository;
        _userContext = userContext;
        _mapper = mapper;
    }
    public async Task Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _toDoItemsRepository.GetByIdAsync(request.Id);
        if (item is null)
            throw new NotFoundException(nameof(item), request.Id.ToString());

        int? loggedInUserId = _userContext.UserId;
        if (loggedInUserId != item.UserId) throw new ForbidException("You can not update task you do not own");
        _mapper.Map(request, item);


        await _toDoItemsRepository.SaveChanges();
    }
}
