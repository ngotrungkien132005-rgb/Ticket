using System.ComponentModel.DataAnnotations;

namespace Ticket.Models
{
    public class Move
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Move name must be between 3 and 100 characters.")]
        public string Title { get; set; }

        public string RealeaseDate { get; set; }

        public int Duration { get; set; }

        public int GenreId { get; set; }
    }
}
