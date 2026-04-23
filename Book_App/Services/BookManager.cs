using Book_App.Enums;
using Book_App.Interfaces;
using Book_App.Models;

namespace Book_App.Services
{
    public class BookManager
    {
        private readonly IBookRepository repository;

        public BookManager(IBookRepository repo)
        {
            repository = repo;
        }

        public bool AddBook(Book book)
        {
            if (repository.FindByTitle(book.Title) != null)
                return false;

            repository.Add(book);
            return true;
        }

        public List<Book> GetAllBooks() => repository.GetAll();

        public Book FindById(int id) => repository.FindById(id);

        public Book FindByTitle(string title) => repository.FindByTitle(title);

        public List<Book> FindByAuthor(string author) => repository.FindByAuthor(author);

        public List<Book> FindByYear(int year) => repository.FindByYear(year);

        public List<Book> FindByGenre(Genre genre) => repository.FindByGenre(genre);

        public void DeleteBook(int id) => repository.Delete(id);

        public void UpdateBook(int id, Book updatedBook) => repository.Update(id, updatedBook);

        public void AddRating(int id, int rating)
        {
            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Rating must be between 1 and 5.");
                return;
            }

            repository.AddRating(id, rating);
        }
    }
}
