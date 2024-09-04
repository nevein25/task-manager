using AutoMapper;
using MediatR;
using ToDo.Application.Users;
using ToDo.Domain.Entities;
using ToDo.Domain.Repositories;

namespace ToDo.Application.ToDoItems.Commands.CreateToDoItem;
internal class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, int>
{
    private readonly IToDoItemsRepository _toDoItemsRepository;
    private readonly IUserContext _userContext;
    private readonly IMapper _mapper;

    public CreateToDoItemCommandHandler(IToDoItemsRepository toDoItemsRepository,
                                    IUserContext userContext,
                                    IMapper mapper)
    {
        _toDoItemsRepository = toDoItemsRepository;
        _userContext = userContext;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId;
        var item = _mapper.Map<ToDoItem>(request);

        if (userId == null) throw new InvalidOperationException("User Id is not available.");



        item.UserId = userId.Value;

        int itemId = await _toDoItemsRepository.Create(item);
        return itemId;
    }
}
