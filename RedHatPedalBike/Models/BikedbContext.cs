using Microsoft.EntityFrameworkCore;
using RedHatPedalBike.Models;

namespace RedHatPedalBike.Models
{
    public class BikedbContext : DbContext
    {
        public BikedbContext(DbContextOptions<BikedbContext> options)
            : base(options)
        {


        }
        public virtual DbSet<Bike> Bike { get; set; }
    }
}