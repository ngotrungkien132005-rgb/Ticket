using System.ComponentModel.DataAnnotations;

namespace Ticket.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Genre name must be between 3 and 100 characters.")]
        public string Name { get; set; }

    }
}
