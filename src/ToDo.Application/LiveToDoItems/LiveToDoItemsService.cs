using Newtonsoft.Json;
using ToDo.Application.Interfaces;
using ToDo.Application.ToDoItems.DTOs;

namespace ToDo.Application.LiveToDoItems;
public class LiveToDoItemsService : ILiveToDoItemsService
{
    private readonly HttpClient _httpClient;

    public LiveToDoItemsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ToDoItemDto>> GetLiveToDoItemsAsync(int page, int pageSize)
    {
        var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/todos?_page={page}&_limit={pageSize}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var liveToDoItems = JsonConvert.DeserializeObject<IEnumerable<ToDoItemDto>>(json);
        return liveToDoItems;
    }
}

