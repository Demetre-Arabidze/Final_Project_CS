using Book_App.Enums;
using Book_App.Interfaces;
using Book_App.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Book_App.Repositories
{
    public class FileBookRepository : IBookRepository
    {
        private readonly string filePath = @"../../../books.json";

        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() } 
        };

        public void Add(Book book)
        {
            var books = GetAll();

            int newId = GetNextId(books);

            var newBook = new Book(
                newId,
                book.Title,
                book.Author,
                book.Year,
                book.Genre 
            )
            {
                Ratings = book.Ratings 
            };

            books.Add(newBook);
            SaveToFile(books);
        }

        public List<Book> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<Book>();

            var json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Book>();

            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        public Book FindByTitle(string title)
        {
            return GetAll()
                .FirstOrDefault(b =>b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public void Delete(int id)
        {
            var books = GetAll();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
                SaveToFile(books);
            }
        }

        public void Update(int id, Book updatedBook)
        {
            var books = GetAll();

            var index = books.FindIndex(b => b.Id == id);

            if (index < 0)
            {
                books[index] = new Book(
                    id,
                    updatedBook.Title,
                    updatedBook.Author,
                    updatedBook.Year,
                    updatedBook.Genre 
                )
                {
                    Ratings = updatedBook.Ratings 
                };

                SaveToFile(books);
            }
        }

        public int GetNextId(List<Book> books)
        {
            if (books.Count == 0)
                return 1;

            return books.Max(b => b.Id) + 1;
        }

        public Book FindById(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }

        public List<Book> FindByAuthor(string author)
        {
            return GetAll()
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Book> FindByYear(int year)
        {
            return GetAll()
                .Where(b => b.Year == year).ToList();
        }

        public List<Book> FindByGenre(Genre genre)
        {
            return GetAll()
                .Where(b => b.Genre == genre).ToList();
        }

        public void AddRating(int id, int rating)
        {
            var books = GetAll();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.Ratings.Add(rating);
                SaveToFile(books);
            }
        }

        private void SaveToFile(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, options);
            File.WriteAllText(filePath, json);
        }
    }
}
