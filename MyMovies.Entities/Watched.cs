using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Entities
{
    [Table("watched")]
    public class Watched : Movie
    {
        DateTime date = DateTime.Now;
        
        [MaxLength(150)]
        [Display(Name = "O que achou", Order = 2)]
        public string? Comment { get; set; }
        
        [Required]
        [Display(Name = "Data", Order = 3, Prompt = "dd/mm/aaaa")]
        public DateTime Date { get { return date; } set { date = value; } }
    }
}
