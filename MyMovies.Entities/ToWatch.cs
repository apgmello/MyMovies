using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Entities
{
    [Table("towatch")]
    public class ToWatch : Movie
    {
        [MaxLength(150)]
        [Display(Name = "Motivo", Order = 2)]
        public string? Reason { get; set; }
    }
}
