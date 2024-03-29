using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchichtNew.Models;

namespace SchichtNew.Data
{
    public class SchichtDbContext : IdentityDbContext<User>
    {
        public SchichtDbContext(DbContextOptions<SchichtDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
