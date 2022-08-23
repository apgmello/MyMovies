using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Entities
{
    public abstract class Movie
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty]        
        public long Id { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
