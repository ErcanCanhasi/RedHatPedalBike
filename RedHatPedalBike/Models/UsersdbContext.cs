using Microsoft.EntityFrameworkCore;
using RedHatPedalBike.Models;

namespace RedHatPedalBike.Models
{
    public class UsersdbContext : DbContext
    {
        public UsersdbContext(DbContextOptions<UsersdbContext> options)
            : base(options)
        {


        }
        public virtual DbSet<Users> Users { get; set; }
    }
}