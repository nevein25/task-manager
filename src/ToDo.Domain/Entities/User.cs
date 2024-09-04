using Microsoft.AspNetCore.Identity;

namespace ToDo.Domain.Entities;
public class User : IdentityUser<int>
{

    public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem> ();
}
