using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCheckOO
{
    public interface ShelfInterface
    {
        public int GetLength();
        public Book GetBook(int index);
    }

    public class Shelf : ShelfInterface
    {
        private int Length;
        private Book[] Contents;

        public Shelf (int length)
        {
            Length = length;
            Contents = Populator.PopulateShelf(length);
        }

        public int GetLength()
        {
            return Length;
        }

        public Book GetBook(int index)
        {
            return Contents[index];
        }
    }
}
