using Book_App.Enums;
using Book_App.Models;
using Book_App.Services;

namespace Book_App.UI
{
    public class ConsoleUI
    {
        private readonly BookManager manager;

        public ConsoleUI(BookManager manager)
        {
            this.manager = manager;
        }

        public void Start()
        {
            while (true)
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
                    case "1": AddBook(); break;
                    case "2": ShowAllBooks(); break;
                    case "3": SearchBook(); break;
                    case "4": UpdateBook(); break;
                    case "5": DeleteBook(); break;
                    case "6": RateBook(); break;
                    case "7": return;
                    default: Console.WriteLine("Invalid option!"); break;
                }
            }
        }

        private void AddBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            int year;
            Console.Write("Year: ");
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year. Try again:");
            }

            foreach (var g in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{(int)g} - {g}");
            }

            Console.Write("Select Genre:");
            int genreChoice;
            while (!int.TryParse(Console.ReadLine(), out genreChoice) ||
                   !Enum.IsDefined(typeof(Genre), genreChoice))
            {
                Console.WriteLine("Invalid genre. Try again:");
            }

            Genre genre = (Genre)genreChoice;

            var book = new Book(title, author, year)
            {
                Genre = genre
            };

            var success = manager.AddBook(book);

            Console.WriteLine(success
                ? "Book added successfully!"
                : "Book already exists!");
        }

        private void ShowAllBooks()
        {
            Console.WriteLine("\n--- View All Books ---");
            Console.WriteLine("1. By ID (Default)");
            Console.WriteLine("2. By Year (Ascending)");
            Console.WriteLine("3. By Year (Descending)");
            Console.WriteLine("4. By Rating (Highest First)");
            Console.WriteLine("5. By Rating (Lowest First)");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            var books = manager.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            List<Book> sortedBooks = choice switch
            {
                "1" => books.OrderBy(b => b.Id).ToList(),
                "2" => books.OrderBy(b => b.Year).ToList(),
                "3" => books.OrderByDescending(b => b.Year).ToList(),
                "4" => books.OrderByDescending(b => b.Ratings.Any() ? b.Ratings.Average() : 0).ToList(),
                "5" => books.OrderBy(b => b.Ratings.Any() ? b.Ratings.Average() : 0).ToList(),
                _ => books.OrderBy(b => b.Id).ToList()
            };

            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book);
            }
        }

        #region
        private void SearchBook()
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
                case "1": SearchBookById(); break;
                case "2": SearchBookByTitle(); break;
                case "3": SearchBookByAuthor(); break;
                case "4": SearchBookByYear(); break;
                case "5": SearchByGenre(); break;
                default: Console.WriteLine("Invalid option!"); break;
            }
        }
        private void SearchBookByTitle()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            var book = manager.FindByTitle(title);

            if (book == null)
                Console.WriteLine("Book not found.");
            else
                Console.WriteLine(book);
        }

        private void SearchBookById()
        {
            Console.Write("Enter ID: ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. Try again:");
            }

            var book = manager.FindById(id);

            if (book == null)
                Console.WriteLine("Book not found.");
            else
                Console.WriteLine(book);
        }

        private void SearchBookByAuthor()
        {
            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            var books = manager.FindByAuthor(author);

            if (books.Count == 0)
            {
                Console.WriteLine("No books found for this author.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private void SearchBookByYear()
        {
            Console.Write("Enter year: ");

            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year. Try again:");
            }

            var books = manager.FindByYear(year);

            if (books.Count == 0)
            {
                Console.WriteLine("No books found for this year.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private void SearchByGenre()
        {

            foreach (var g in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{(int)g} - {g}");
            }

            Console.Write("Select Genre:");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   !Enum.IsDefined(typeof(Genre), choice))
            {
                Console.WriteLine("Invalid choice. Try again:");
            }

            var genre = (Genre)choice;

            var books = manager.FindByGenre(genre);

            if (books.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        #endregion

        private void DeleteBook()
        {
            Console.Write("Enter id to delete: ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid id. Try again:");
            }

            manager.DeleteBook(id);

            Console.WriteLine("If book existed, it was deleted.");
        }

        private void UpdateBook()
        {
            Console.Write("Enter ID to update: ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. Try again:");
            }

            Console.Write("New Title: ");
            string title = Console.ReadLine();

            Console.Write("New Author: ");
            string author = Console.ReadLine();

            int year;
            Console.Write("New Year: ");
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year. Try again:");
            }

            foreach (var g in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{(int)g} - {g}");
            }

            Console.Write("Select Genre:");
            int genreChoice;
            while (!int.TryParse(Console.ReadLine(), out genreChoice) ||
                   !Enum.IsDefined(typeof(Genre), genreChoice))
            {
                Console.WriteLine("Invalid genre. Try again:");
            }

            Genre genre = (Genre)genreChoice;

            var updatedBook = new Book(title, author, year)
            {
                Genre = genre
            };

            manager.UpdateBook(id, updatedBook);

            Console.WriteLine("Book updated (if it existed).");
        }

        private void RateBook()
        {
            Console.Write("Enter Book ID: ");

            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. Try again:");
            }

            Console.Write("Enter rating (1-5): ");

            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating. Enter value between 1 and 5:");
            }

            manager.AddRating(id, rating);

            Console.WriteLine("Rating added!");
        }
    }
}
