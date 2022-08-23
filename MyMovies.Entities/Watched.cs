using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Entities
{
    [Table("watched")]
    public class Watched : Movie
    {
        [MaxLength(150)]
        public string Comment { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
    }
}
