using System.ComponentModel.DataAnnotations;

namespace MyMovies.Entities.Dto
{
    public class ToWatchSearchDto : IDto
    {
        private string title = "";
        private string reason = "";

        [Display(Name = "Título", Order = 1)]
        public string? Title
        {
            get { return title; }
            set { title = value ?? ""; }
        }


        [Display(Name = "Motivo", Order = 2)]
        public string? Reason
        {
            get { return reason; }
            set { reason = value ?? ""; }
        }
    }
}
