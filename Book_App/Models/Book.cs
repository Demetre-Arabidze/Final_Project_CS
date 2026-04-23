using Book_App.Enums;
using System.Text.Json.Serialization;

namespace Book_App.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre Genre { get; set; }
        public List<int> Ratings { get; set; } = new List<int>();
        public double AverageRating => Ratings.Count == 0 ? 0 : Ratings.Average();

        public Book() { }

        public Book(int id, string title, string author, int year, Genre genre)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
        }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Title: {Title} - Author: {Author}, Year: {Year} | Genre: {Genre} | Rating: {AverageRating:F1}";
        }
    }
}
