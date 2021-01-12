using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCheckOO
{
    public class Populator
    {
        public static string PopulateTitle ()
        {
            List<string> TitleA = new List<string> { "Harry Potter", "The Lord of the Rings", "The Maze Runner" };
            List<string> TitleB = new List<string> { " and the ", ": ", " with the " };
            List<string> TitleC = new List<string> { "Philosopher's Stone", "Chamber of Secrets", "Prisoner of Azkaban", "Goblet of Fire", "Order of the Pheonix", "Half Blood Prince", "Deathly Hallows", "Fellowship of the Ring", "Two Towers", "Return of the King", "The Maze Runner", "The Scorch Trials", "The Death Cure", "The Kill Order"};

            Random r = new Random();

            return string.Concat(TitleA[r.Next(0, TitleA.Count)], TitleB[r.Next(0, TitleB.Count)], TitleC[r.Next(0, TitleC.Count)]);
        }

        public static string PopulateAuthor()
        {
            List<string> AuthorA = new List<string> { "J.K. ", "J.R.R. ", "James " };
            List<string> AuthorB = new List<string> { "Rowling", "Tolkein", "Dasher"};

            Random r = new Random();

            return string.Concat(AuthorA[r.Next(0, AuthorA.Count)], AuthorB[r.Next(0, AuthorB.Count)]);
        }

        public static Book PopulateBook ()
        {
            Random r = new Random();
            int id = r.Next(100000000);
            string title = PopulateTitle();
            string author = PopulateAuthor();
            bool borrowed = !Convert.ToBoolean(r.Next(10));

            return new Book(id, title, author, borrowed);
        }

        public static Book[] PopulateShelf (int Length)
        {
            Book[] books = new Book[Length];

            for (int i = 0; i < Length; i++)
            {
                books[i] = PopulateBook();
            }

            return books;
        }
    }
}
