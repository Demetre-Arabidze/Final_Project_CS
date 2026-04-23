using Book_App.Models;
using Book_App.Services;
using Book_App_Repository.Models.Enums;
using Book_App_Services.DTOs;

namespace Book_App.UI
{
    public class ConsoleUI
    {
        private readonly BookManager manager;

        public ConsoleUI(BookManager manager)
        {
            this.manager = manager;
        }

        public async Task StartAsync()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n--- Book Manager ---");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. View All Books");
                    Console.WriteLine("3. Search Book");
                    Console.WriteLine("4. Update Book");
                    Console.WriteLine("5. Delete Book");
                    Console.WriteLine("6. Rate Book");
                    Console.WriteLine("7. Exit");

                    Console.Write("Choose option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1": await AddBook(); break;
                        case "2": await ShowAllBooks(); break;
                        case "3": await SearchBook(); break;
                        case "4": await UpdateBook(); break;
                        case "5": await DeleteBook(); break;
                        case "6": await RateBook(); break;
                        case "7": return;
                        default: Console.WriteLine("Invalid option!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        private async Task AddBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(title))
            {
                Console.Write("Title cannot be empty: ");
                title = Console.ReadLine();
            }

            Console.Write("Author: ");
            string author = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(author))
            {
                Console.Write("Author cannot be empty: ");
                author = Console.ReadLine();
            }

            Console.Write("Year: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
                Console.Write("Invalid year: ");

            foreach (var g in Enum.GetValues(typeof(Genre)))
                Console.WriteLine($"{(int)g} - {g}");

            Console.Write("Select Genre: ");
            int genreChoice;

            while (!int.TryParse(Console.ReadLine(), out genreChoice) ||
                   !Enum.IsDefined(typeof(Genre), genreChoice))
                Console.Write("Invalid genre: ");

            var dto = new CreateBookDto
            {
                Title = title,
                Author = author,
                Year = year,
                Genre = (Genre)genreChoice
            };

            await manager.AddBook(dto);

            Console.WriteLine("Book added successfully!");
        }

        private async Task ShowAllBooks()
        {
            var books = await manager.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            Console.WriteLine("\n--- View All Books ---");
            Console.WriteLine("1. By ID");
            Console.WriteLine("2. By Year ASC");
            Console.WriteLine("3. By Year DESC");
            Console.WriteLine("4. By Rating DESC");
            Console.WriteLine("5. By Rating ASC");

            string choice = Console.ReadLine();

            var sorted = choice switch
            {
                "2" => books.OrderBy(b => b.Year),
                "3" => books.OrderByDescending(b => b.Year),
                "4" => books.OrderByDescending(b => b.AverageRating),
                "5" => books.OrderBy(b => b.AverageRating),
                _ => books.OrderBy(b => b.Id)
            };

            foreach (var book in sorted)
                Console.WriteLine(book);
        }

        #region
        private async Task SearchBook()
        {
            Console.WriteLine("\n--- Search Book ---");
            Console.WriteLine("1. By ID");
            Console.WriteLine("2. By Title");
            Console.WriteLine("3. By Author");
            Console.WriteLine("4. By Year");
            Console.WriteLine("5. By Genre");

            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": await SearchById(); break;
                case "2": await SearchByTitle(); break;
                case "3": await SearchByAuthor(); break;
                case "4": await SearchByYear(); break;
                case "5": await SearchByGenre(); break;
                default: Console.WriteLine("Invalid option!"); break;
            }
        }

        private async Task SearchById()
        {
            Console.Write("Enter ID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
                Console.Write("Invalid ID: ");

            var book = await manager.FindById(id);

            Console.WriteLine("Book Not found");
        }

        private async Task SearchByTitle()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            var book = await manager.FindByTitle(title);

            Console.WriteLine("Book Not found");
        }

        private async Task SearchByAuthor()
        {
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            var books = await manager.FindByAuthor(author);

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            foreach (var book in books)
                Console.WriteLine(book);
        }

        private async Task SearchByYear()
        {
            Console.Write("Enter Year: ");
            int year;

            while (!int.TryParse(Console.ReadLine(), out year))
                Console.Write("Invalid year: ");

            var books = await manager.FindByYear(year);

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            foreach (var book in books)
                Console.WriteLine(book);
        }

        private async Task SearchByGenre()
        {
            foreach (var g in Enum.GetValues(typeof(Genre)))
                Console.WriteLine($"{(int)g} - {g}");

            Console.Write("Select Genre: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   !Enum.IsDefined(typeof(Genre), choice))
                Console.Write("Invalid genre: ");

            var books = await manager.FindByGenre((Genre)choice);

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            foreach (var book in books)
                Console.WriteLine(book);
        }
        #endregion

        private async Task DeleteBook()
        {
            Console.Write("Enter ID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
                Console.Write("Invalid ID: ");

            await manager.DeleteBook(id);

            Console.WriteLine("Deleted.");
        }

        private async Task UpdateBook()
        {
            Console.Write("Enter ID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
                Console.Write("Invalid ID: ");

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Year: ");
            int year;

            while (!int.TryParse(Console.ReadLine(), out year))
                Console.Write("Invalid year: ");

            foreach (var g in Enum.GetValues(typeof(Genre)))
                Console.WriteLine($"{(int)g} - {g}");

            Console.Write("Genre: ");
            int genreChoice;

            while (!int.TryParse(Console.ReadLine(), out genreChoice) ||
                   !Enum.IsDefined(typeof(Genre), genreChoice))
                Console.Write("Invalid genre: ");

            var dto = new UpdateBookDto
            {
                Title = title,
                Author = author,
                Year = year,
                Genre = (Genre)genreChoice
            };

            await manager.UpdateBook(id, dto);

            Console.WriteLine("Updated successfully!");
        }

        private async Task RateBook()
        {
            Console.Write("Enter ID: ");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
                Console.Write("Invalid ID: ");

            Console.Write("Rating (1-5): ");
            int rating;

            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
                Console.Write("Invalid rating: ");

            await manager.AddRating(id, rating);

            Console.WriteLine("Rating added!");
        }
    }
}
