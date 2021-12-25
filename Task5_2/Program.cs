using System;
using System.Collections.Generic;

namespace Task5_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var h1 = new HashSet<string>
            {
                "a",
                "b",
                "c"
            };
            var b1 = new Book("book 2", DateTime.Now.AddDays(2), h1);
            var isbn1 = new Isbn("123-4-56-789012-3");

            var h2 = new HashSet<string>
            {
                "a",
                "b",
                "d"
            };
            var b2 = new Book("book 3", DateTime.Now.AddDays(1), h2);
            var isbn2 = new Isbn("2234567890123");

            var h3 = new HashSet<string>
            {
                "e",
                "b",
                "d"
            };
            var b3 = new Book("book 4", DateTime.Now.AddDays(4), h3);
            var isbn3 = new Isbn("3234567890123");

            var c1 = new Catalog
            {
                {isbn1, b1},
                {isbn2, b2},
                {isbn3, b3}
            };

            var equalsIsbn1 = new Isbn("123-4-56-789012-3");
            var equalsIsbn2 = new Isbn("1234567890123");
            Console.WriteLine("Test equalsIsbn 123-4-56-789012-3 and 1234567890123:");
            Console.WriteLine(c1[equalsIsbn1].Name);
            Console.WriteLine(c1[equalsIsbn2].Name);
            Console.WriteLine(equalsIsbn1.Equals(equalsIsbn2));
            Console.WriteLine();

            Console.WriteLine("Dictionary:");
            foreach (var (isbn, book) in c1)
            {
                Console.WriteLine(isbn + "; " + book.Name);
            }

            Console.WriteLine("GetAuthorsInfo():");
            var authorsInfo = c1.GetAuthorsInfo();
            foreach (var (author, booksCount) in authorsInfo)
            {
                Console.WriteLine($"{author}, - {booksCount}");
            }

            Console.WriteLine();
            Console.WriteLine("GetSortedBooksNames():");
            var sortedBooksNames = c1.GetSortedBooksNames();
            foreach (var bookName in sortedBooksNames)
            {
                Console.WriteLine($"{bookName}");
            }

            Console.WriteLine();
            Console.WriteLine("GetSortedBooksByAuthors(b):");
            var sortedBooksByAuthors = c1.GetSortedBooksByAuthors("b");
            foreach (var book in sortedBooksByAuthors)
            {
                Console.WriteLine($"{book.Name}, - {book.Date}");
            }
        }
    }
}