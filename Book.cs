using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCheckOO
{
    public interface BookInterface
    {
        public int GetID();
        public string GetTitle();
        public string GetAuthor();
        public bool IsBorrowed();

        public void TakeBook();
        public void ReturnBook();
    }

    public class Book : BookInterface
    {
        private int ID;
        private string Title;
        private string Author;
        private bool Borrowed;

        public Book (int id, string title, string author, bool borrowed)
        {
            ID = id;
            Title = title;
            Author = author;
            Borrowed = borrowed;
        }

        public int GetID()
        {
            return ID;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetAuthor()
        {
            return Author;
        }

        public bool IsBorrowed()
        {
            return Borrowed;
        }

        public void TakeBook ()
        {
            Borrowed = true;

        }

        public void ReturnBook ()
        { 
            Borrowed = false;
        }
    }
}
