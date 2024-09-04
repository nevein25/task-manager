using FluentValidation;

namespace ToDo.Application.ToDoItems.Commands.UpdateToDoItem;
public class UpdateToDoItemCommandValidator : AbstractValidator<UpdateToDoItemCommand>
{
    public UpdateToDoItemCommandValidator()
    {

        RuleFor(dto => dto.Title).NotEmpty();
    }
}
