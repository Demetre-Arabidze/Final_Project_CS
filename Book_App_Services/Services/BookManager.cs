using Book_App.Interfaces;
using Book_App.Models;
using Book_App_Repository.Models.Enums;

namespace Book_App.Services
{
    public class BookManager
    {
        private readonly IBookRepository repository;

        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }

        public void AddBook(Book book)
            => repository.Add(book);

        public List<Book> GetAllBooks()
            => repository.GetAll();

        public Book FindById(int id)
            => repository.FindById(id);

        public Book FindByTitle(string title)
            => repository.FindByTitle(title);

        public List<Book> FindByAuthor(string author)
            => repository.FindByAuthor(author);

        public List<Book> FindByYear(int year)
            => repository.FindByYear(year);

        public List<Book> FindByGenre(Genre genre)
            => repository.FindByGenre(genre);

        public void UpdateBook(int id, Book book)
            => repository.Update(id, book);

        public void DeleteBook(int id)
            => repository.Delete(id);

        public void AddRating(int id, int rating)
            => repository.AddRating(id, rating);
    }
}
