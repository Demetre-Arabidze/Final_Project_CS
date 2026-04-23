using Book_App.Interfaces;
using Book_App.Models;
using Book_App_Repository.Models.Enums;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Book_App.Repositories
{
    public class FileBookRepository : IBookRepository
    {
        private readonly string filePath;

        public FileBookRepository()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            filePath = Path.Combine(baseDir, "books.json");
        }

        private JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public List<Book> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<Book>();

            var json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Book>();

            return JsonSerializer.Deserialize<List<Book>>(json, options)
                   ?? new List<Book>();
        }

        public void Add(Book book)
        {
            var books = GetAll();

            book.Id = GetNextId(books);

            books.Add(book);
            Save(books);
        }

        public void Update(int id, Book updatedBook)
        {
            var books = GetAll();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Year = updatedBook.Year;
                book.Genre = updatedBook.Genre;

                Save(books);
            }
        }

        public void Delete(int id)
        {
            var books = GetAll();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
                Save(books);
            }
        }

        public Book FindById(int id)
            => GetAll().FirstOrDefault(b => b.Id == id);

        public List<Book> FindByAuthor(string author)
            => GetAll()
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();

        public List<Book> FindByYear(int year)
            => GetAll().Where(b => b.Year == year).ToList();

        public List<Book> FindByGenre(Genre genre)
            => GetAll().Where(b => b.Genre == genre).ToList();

        public Book FindByTitle(string title)
            => GetAll().FirstOrDefault(b =>
                b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        public void AddRating(int id, int rating)
        {
            var books = GetAll();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.Ratings.Add(rating);
                Save(books);
            }
        }

        private int GetNextId(List<Book> books)
            => books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;

        private void Save(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(filePath, json);
        }
    }
}

