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

        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        public FileBookRepository()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(baseDir, "books.json");
        }

        public async Task<List<Book>> GetAllAsync()
        {
            if (!File.Exists(filePath))
                return new List<Book>();

            var json = await File.ReadAllTextAsync(filePath);

            if (string.IsNullOrWhiteSpace(json))
                return new List<Book>();

            return JsonSerializer.Deserialize<List<Book>>(json, options) ?? new List<Book>();
        }

        public async Task AddAsync(Book book)
        {
            var books = await GetAllAsync();
            book.Id = books.Count == 0 ? 1 : books.Max(b => b.Id) + 1;

            books.Add(book);
            await SaveAsync(books);
        }

        public async Task UpdateAsync(int id, Book updatedBook)
        {
            var books = await GetAllAsync();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Year = updatedBook.Year;
                book.Genre = updatedBook.Genre;

                await SaveAsync(books);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var books = await GetAllAsync();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
                await SaveAsync(books);
            }
        }

        public async Task<Book> FindByIdAsync(int id)
            => (await GetAllAsync()).FirstOrDefault(b => b.Id == id);

        public async Task<List<Book>> FindByAuthorAsync(string author)
            => (await GetAllAsync())
                .Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                .ToList();

        public async Task<List<Book>> FindByYearAsync(int year)
            => (await GetAllAsync()).Where(b => b.Year == year).ToList();

        public async Task<List<Book>> FindByGenreAsync(Genre genre)
            => (await GetAllAsync()).Where(b => b.Genre == genre).ToList();

        public async Task<Book> FindByTitleAsync(string title)
            => (await GetAllAsync())
                .FirstOrDefault(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        public async Task AddRatingAsync(int id, int rating)
        {
            var books = await GetAllAsync();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                book.Ratings ??= new List<int>();
                book.Ratings.Add(rating);

                await SaveAsync(books);
            }
        }

        private async Task SaveAsync(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, options);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}

