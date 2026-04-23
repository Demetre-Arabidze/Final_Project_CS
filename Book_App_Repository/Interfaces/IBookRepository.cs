using Book_App.Models;
using Book_App_Repository.Models.Enums;

namespace Book_App.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(int id, Book updatedBook);
        Task DeleteAsync(int id);
        Task<Book> FindByIdAsync(int id);
        Task<List<Book>> FindByAuthorAsync(string author);
        Task<List<Book>> FindByYearAsync(int year);
        Task<List<Book>> FindByGenreAsync(Genre genre);
        Task<Book> FindByTitleAsync(string title);
        Task AddRatingAsync(int id, int rating);
    }
}
