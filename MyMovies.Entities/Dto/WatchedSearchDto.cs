using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyMovies.Entities.Dto
{
    public class WatchedSearchDto : Dto
    {
        private string title = "";
        private string comment = "";
        private string date = "01/01/0001";
        
        [Display(Name = "Título", Order = 1)]
        public string? Title 
        {
            get { return title; }
            set { title = value ?? ""; }
        }

        [Display(Name = "Comentário", Order = 2)]
        public string? Comment 
        {
            get { return comment; }
            set { comment = value ?? ""; }
        }

        [Display(Name = "Data", Order = 3)]
        public string? Date 
        {
            get { return date; }
            set { date = value ?? "01/01/0001"; }
        }
    }
}
