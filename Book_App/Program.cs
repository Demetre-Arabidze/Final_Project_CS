using Book_App.Interfaces;
using Book_App.Repositories;
using Book_App.Services;
using Book_App.UI;

namespace Book_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBookRepository repo = new FileBookRepository();
            var manager = new BookManager(repo);

            var ui = new ConsoleUI(manager);
            ui.Start();
        }
    }
}
