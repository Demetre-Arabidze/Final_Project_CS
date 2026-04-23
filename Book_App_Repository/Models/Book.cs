using Book_App.Attributes;
using Book_App_Repository.Models.Enums;
using System.Text.Json.Serialization;

namespace Book_App.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2, 50)]
        public string Title { get; set; }

        [Required]
        [StringLength(2, 50)]
        public string Author { get; set; }

        [Year]
        public int Year { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public List<int> Ratings { get; set; } = new();

        public Book(int id, string title, string author, int year, Genre genre)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
        }

        public Book()
        {
            Ratings = new List<int>();
        }

        public double AverageRating => Ratings.Count == 0 ? 0 : Ratings.Average();

        public override string ToString()
        {
            return $"ID: {Id} | {Title} - {Author} ({Year}) | {Genre} | Rating: {AverageRating:F1}";
        }
    }
}

