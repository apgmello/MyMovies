using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Entities
{
    [Table("towatch")]
    public class ToWatch : Movie
    {
        [MaxLength(150)]

        public string Reason { get; set; }
    }
}
