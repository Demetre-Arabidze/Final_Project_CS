using Book_App.Interfaces;
using Book_App.Models;
using Book_App_Repository.Models.Enums;
using Book_App_Services.DTOs;

namespace Book_App.Services
{
    public class BookManager
    {
        private readonly IBookRepository repository;

        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }

        public Task AddBook(CreateBookDto dto)
            => repository.AddAsync(new Book(0, dto.Title, dto.Author, dto.Year, dto.Genre));

        public Task UpdateBook(int id, UpdateBookDto dto)
            => repository.UpdateAsync(id, new Book(id, dto.Title, dto.Author, dto.Year, dto.Genre));

        public Task<List<Book>> GetAllBooks()
            => repository.GetAllAsync();

        public Task<Book> FindById(int id)
            => repository.FindByIdAsync(id);

        public Task DeleteBook(int id)
            => repository.DeleteAsync(id);

        public Task AddRating(int id, int rating)
            => repository.AddRatingAsync(id, rating);


        public Task<Book> FindByTitle(string title)
            => repository.FindByTitleAsync(title);

        public Task<List<Book>> FindByAuthor(string author)
            => repository.FindByAuthorAsync(author);

        public Task<List<Book>> FindByYear(int year)
            => repository.FindByYearAsync(year);

        public Task<List<Book>> FindByGenre(Genre genre)
            => repository.FindByGenreAsync(genre);
    }
}