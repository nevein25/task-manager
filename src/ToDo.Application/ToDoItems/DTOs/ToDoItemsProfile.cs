using AutoMapper;
using ToDo.Application.ToDoItems.Commands.CreateToDoItem;
using ToDo.Application.ToDoItems.Commands.UpdateToDoItem;
using ToDo.Domain.Entities;
namespace ToDo.Application.ToDoItems.DTOs;

internal class ToDoItemsProfile : Profile
{
    public ToDoItemsProfile()
    {
        CreateMap<CreateToDoItemCommand, ToDoItem>();
        CreateMap<ToDoItem, ToDoItemDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.UserName));
        CreateMap<UpdateToDoItemCommand, ToDoItem>();
    }
}
