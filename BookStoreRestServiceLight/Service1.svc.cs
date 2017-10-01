using System.Collections.Generic;
using System.Linq;

namespace BookStoreRestServiceLight
{
   public class BookStoreService : IBookstoreService
    {
        private static readonly IList<Book> Books = new List<Book>();
        private static int _nextId = 4;

        static BookStoreService()
        {
            Book firstBook = new Book
            {
                Id = 1,
                Title = "C# 5.0",
                Publisher = "Wrox",
                Author = "Nagel",
                Price = 123.45
            };
            Books.Add(firstBook);
            Books.Add(new Book
            {
                Id = 2,
                Title = "Beginning Android 4 Application Development",
                Publisher = "Wrox",
                Author = "Wei-Meng Lee",
                Price = 39.99
            });
            Books.Add(new Book
            {
                Id = 3,
                Title = "Android Application Development in 24 Hours",
                Publisher = "Sams",
                Author = "Carmen Delessio",
                Price = 49.99
            });
        }

        public IList<Book> GetBooks()
        {
            return Books;
        }

        public Book GetBook(string id)
        {
            int idNumber = int.Parse(id);
            return Books.FirstOrDefault(book => book.Id == idNumber);
        }

        public string GetBookTitle(string id)
        {
            Book book = GetBook(id);
            if (book == null) return null;
            return book.Title;
        }

        public IEnumerable<Book> GetBooksByTite(string titleFragment)
        {
            // http://stackoverflow.com/questions/444798/case-insensitive-containsstring
            return Books.Where(book => book.Title.ToLower().Contains(titleFragment.ToLower()));
        }

        public Book AddBook(Book book)
        {
            //book.Id = new Random().Next(100);
            book.Id = _nextId++;
            Books.Add(book);
            return book;
        }

        public Book UpdateBook(string id, Book book)
        {
            int idNumber = int.Parse(id);
            Book existingBook = Books.FirstOrDefault(b => b.Id == idNumber);
            if (existingBook == null) return null;
            existingBook.Title = book.Title;
            existingBook.Publisher = book.Publisher;
            existingBook.Author = book.Author;
            return existingBook;
        }

        public Book DeleteBook(string id)
        {
            Book book = GetBook(id);
            if (book == null) return null;
            bool removed = Books.Remove(book);
            if (removed) return book;
            return null;
        }
    }
}
