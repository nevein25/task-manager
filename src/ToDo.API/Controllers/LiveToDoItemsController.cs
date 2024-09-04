using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Interfaces;

namespace TodoManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LiveToDoItemsController : ControllerBase
{
    private readonly ILiveToDoItemsService _liveToDoItemsService;

    public LiveToDoItemsController(ILiveToDoItemsService liveToDoItemsService)
    {
        _liveToDoItemsService = liveToDoItemsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLiveTodos(int page = 1, int pageSize = 10)
    {
        var liveToDoItems = await _liveToDoItemsService.GetLiveToDoItemsAsync(page, pageSize);
        return Ok(liveToDoItems);
    }
}
