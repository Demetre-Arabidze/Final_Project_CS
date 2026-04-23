using Book_App_Repository.Models.Enums;

namespace Book_App_Services.DTOs
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
