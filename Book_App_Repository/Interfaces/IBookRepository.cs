using Book_App.Models;
using Book_App_Repository.Models.Enums;

namespace Book_App.Interfaces
{
    public interface IBookRepository
    {
        void Add(Book book);
        List<Book> GetAll();

        Book FindById(int id);
        Book FindByTitle(string title);

        List<Book> FindByAuthor(string author);
        List<Book> FindByYear(int year);
        List<Book> FindByGenre(Genre genre); 

        void Delete(int id);
        void Update(int id, Book updatedBook);
        void AddRating(int id, int rating);
    }
}
