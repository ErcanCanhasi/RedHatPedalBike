using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using RedHatPedalBike.Models;

namespace RedHatPedalBike.Models
{
    public class Users
    {
        [Key]

        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string Username { get; set; }
        public required string password { get; set; }

    }
}