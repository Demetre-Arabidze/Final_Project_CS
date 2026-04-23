using Book_App_Repository.Models.Enums;
using System.Text.Json.Serialization;

namespace Book_App.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
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

        public double AverageRating => Ratings.Count == 0 ? 0 : Ratings.Average();

        public override string ToString()
        {
            return $"ID: {Id} | {Title} - {Author} ({Year}) | {Genre} | Rating: {AverageRating:F1}";
        }
    }
}

