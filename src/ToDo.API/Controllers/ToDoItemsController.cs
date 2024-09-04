using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.ToDoItems.Commands.CreateToDoItem;
using ToDo.Application.ToDoItems.Commands.DeleteToDoItem;
using ToDo.Application.ToDoItems.Commands.UpdateToDoItem;
using ToDo.Application.ToDoItems.DTOs;
using ToDo.Application.ToDoItems.Queries.GetAllToDoItems;
using ToDo.Application.ToDoItems.Queries.GetToDoItemById;

namespace TodoManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemDto?>> GetById(int id)
    {
        var item = await _mediator.Send(new GetToDoItemByIdQuery(id));
        return Ok(item);
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetAllMatching([FromQuery] GetAllToDoItemsQuery query)
    {
        var items = await _mediator.Send(query);
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> CreateToDoItem(CreateToDoItemCommand command)
    {
        var itemId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { Id = itemId }, null);
    }


    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateToDoItem(int id, UpdateToDoItemCommand command)
    {

        command.Id = id;
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteToDoItem(int id)
    {
        await _mediator.Send(new DeleteToDoItemCommand(id));
        return NoContent();
    }

}
