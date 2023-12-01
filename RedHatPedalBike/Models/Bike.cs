using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedHatPedalBike.Models
{
    [Table("bikes")]
    public class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Bike's name cannot be empty.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Bike's model cannot be empty.")]
        public required string Model { get; set; }

        [Column("date_created")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Bike's price cannot be empty.")]
        public int Price { get; set; }

        public byte Image { get; set; }

        [Required(ErrorMessage = "Bike's warranty status cannot be empty.")]
        [Column("warranty_status")]
        public string? WarrantyStatus { get; set; }

        
    }
}
