using System.ComponentModel.DataAnnotations;

namespace Lab6.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Tytul moze miec max 50 znakow")]
        public string Title { get; set; }

        [UIHint("LongText")]
        [Required]
        public string Description { get; set; }
        [Required]
        [UIHint("Stars")]
        [Range(1, 5, ErrorMessage = "Ocena filmu musi byæ liczb¹ pomiêdzy 1 a 5")]
        public int Rating { get; set; }
        [Required]
        public string? TrailerLink { get; set; }
        public Genre Genre { get; set; }
       
    }
}
