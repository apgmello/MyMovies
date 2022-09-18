using Sharprompt;

namespace MyMovies.Entities.Dto
{
    public class Dto
    {
        [BindIgnore]
        public int Page { get; set; }

        [BindIgnore]
        public int MaxResults { get; set; }
    }
}
