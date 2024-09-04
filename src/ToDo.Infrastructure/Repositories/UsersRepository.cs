
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Persistance;


namespace ToDo.Infrastructure.Repositories;
internal class UsersRepository : IUsersRepository
{
    private readonly ToDoManagerDbContext _context;

    public UsersRepository(ToDoManagerDbContext context)
    {
        _context = context;
    }


    public async Task<bool> IsUserExistById(int id) => await _context.Users.AnyAsync(u => u.Id == id);

}
