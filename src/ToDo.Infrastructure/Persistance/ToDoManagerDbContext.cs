using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Persistance;
internal class ToDoManagerDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ToDoManagerDbContext(DbContextOptions<ToDoManagerDbContext> options) : base(options)
    {

    }

    internal DbSet<ToDoItem> ToDoItems { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /// Changing the default table names
        builder.Entity<User>(entity => entity.ToTable("Users"));
        builder.Entity<IdentityRole<int>>(entity => entity.ToTable("Roles"));
        builder.Entity<IdentityUserRole<int>>(entity => entity.ToTable("UserRoles"));
        builder.Entity<IdentityUserClaim<int>>(entity => entity.ToTable("UserClaims"));
        builder.Entity<IdentityUserLogin<int>>(entity => entity.ToTable("UserLogins"));
        builder.Entity<IdentityUserToken<int>>(entity => entity.ToTable("UserTokens"));
        builder.Entity<IdentityRoleClaim<int>>(entity => entity.ToTable("RoleClaims"));
        ///


        ///  [User] 1 <HAS> * [ToDoItem]
        builder.Entity<User>()
            .HasMany(p => p.ToDoItems)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        ///


    }
}
