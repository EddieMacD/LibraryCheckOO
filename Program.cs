using System;

namespace LibraryCheckOO
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const int BookShelves = 2;
                const int BookShelfSize = 6;
                const int ShelfSize = 15;

                Shelf[,] library = new Shelf[BookShelves, BookShelfSize];

                for (int i = 0; i < BookShelves; i++)
                {
                    Shelf[] temp = FillBookShelf(BookShelfSize, ShelfSize);

                    for (int j = 0; j < BookShelfSize; j++)
                    {
                        library[i, j] = temp[j];
                    }
                }

                MenuControl(library);
            }
            catch
            {
                Console.WriteLine("Task Failed");
            }

        }

        static Shelf[] FillBookShelf (int BookShelfSize, int ShelfSize)
        {
            Shelf[] bookShelf = new Shelf[BookShelfSize];

            for(int i = 0; i < BookShelfSize; i++)
            {
                bookShelf[i] = new Shelf(ShelfSize);
            }

            return bookShelf;
        }

        static void MenuControl (Shelf[,] Library)
        {
            int input = 0;

            DisplayMenu();

            do
            {
                input = intInput(0, int.MaxValue, "menu");
                Console.Clear();

                switch (input)
                {
                    case 1:
                        ListBookShelfManager(Library);
                        break;

                    case 2:
                        ListShelfManager(Library);
                        break;

                    case 3:
                        TakeBook(Library);
                        break;

                    case 4:
                        ReturnBook(Library);
                        break;
                }
            } while (input != 0);
        }

        static int intInput(int start, int end, string condition)
        {
            bool valid = false;
            int input = 0;

            while (!valid)
            {
                Console.Write("Enter " + condition + " number: ");

                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (start <= input && input < end)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("That number was out of range. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            }

            return input;
        }

        static void ListBookShelfManager (Shelf[,] Library)
        {
            int bookshelf = intInput(0, Library.GetLength(0), "bookshelf");

            Console.WriteLine("Bookshelf " + bookshelf);

            for(int i = 0; i < Library.GetLength(1); i++)
            {
                Console.WriteLine("Shelf " + i);
                ListShelf(Library[bookshelf, i]);
                Console.WriteLine("");
                Console.WriteLine("");
            }

            OptionEnder();
        }

        static void ListShelfManager (Shelf[,] Library)
        {
            int bookshelf = intInput(0, Library.GetLength(0), "bookshelf");
            int shelf = intInput(0, Library.GetLength(1), "shelf");

            Console.WriteLine("Bookshelf " + bookshelf);
            Console.WriteLine("Shelf " + shelf);
            ListShelf(Library[bookshelf, shelf]);

            OptionEnder();
        }

        private static void OptionEnder()
        {
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();
            Console.Clear();
        }

        static void ListShelf (Shelf shelf)
        {
            for (int i = 0; i < shelf.GetLength(); i++)
            {
                Book book = shelf.GetBook(i);

                Console.Write(book.GetID().ToString().PadLeft(8, '0') + "    " + book.GetTitle() + " by " + book.GetAuthor());

                if (book.IsBorrowed())
                {
                    Console.WriteLine("    This book is not available.");
                }
                else
                {
                    Console.WriteLine("    This book is present.");
                }
            }
        }

        static void TakeBook (Shelf[,] Library)
        {
            int bookshelf = intInput(0, Library.GetLength(0), "bookshelf");
            int shelf = intInput(0, Library.GetLength(1), "shelf");
            Book book = Library[bookshelf, shelf].GetBook(intInput(0, Library[bookshelf, shelf].GetLength(), "book"));
            string confirmation = "";

            if (!book.IsBorrowed())
            {
                Console.Write("Are you sure you want to take: " + book.GetTitle() + " by " + book.GetAuthor() + "(y/n): ");
                confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    book.TakeBook();
                    Console.WriteLine("Book successfully taken.");
                }
            }
            else
            {
                Console.WriteLine("That book is not in the library.");
            }

            OptionEnder();
        }

        static void ReturnBook (Shelf[,] Library)
        {
            int bookshelf = intInput(0, Library.GetLength(0), "bookshelf");
            int shelf = intInput(0, Library.GetLength(1), "shelf");
            Book book = Library[bookshelf, shelf].GetBook(intInput(0, Library[bookshelf, shelf].GetLength(), "book"));
            string confirmation = "";

            if (book.IsBorrowed())
            {
                Console.Write("Are you sure you want to return: " + book.GetTitle() + " by " + book.GetAuthor() + "(y/n): ");
                confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    book.ReturnBook();
                    Console.WriteLine("Book successfully returned.");
                }
            }
            else
            {
                Console.WriteLine("That book is already in the library.");
            }

            OptionEnder();
        }

        static void DisplayMenu ()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Welcome to the Library");
            Console.WriteLine("");
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1: List a bookshelf");
            Console.WriteLine("2: List a shelf");
            Console.WriteLine("3: Take a book");
            Console.WriteLine("4: Return a book");
            Console.WriteLine("");
            Console.WriteLine("0: Exit the system");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
        }
    }
}
