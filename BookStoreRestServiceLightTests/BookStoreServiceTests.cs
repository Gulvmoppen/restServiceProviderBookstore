using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookStoreRestServiceLight.Tests
{
    [TestClass]
    public class BookStoreServiceTests
    {
        [TestMethod]
        public void TestItAll()
        {
            IBookstoreService bookstore = new BookStoreService();
            IList<Book> books = bookstore.GetBooks();
            Assert.AreEqual(3, books.Count);

            Book book = bookstore.GetBook("1");
            Assert.AreEqual("C# 5.0", book.Title);

            Assert.IsNull(bookstore.GetBook("100"));

            Assert.AreEqual("C# 5.0", bookstore.GetBookTitle("1"));
            Assert.IsNull(bookstore.GetBookTitle("100"));

            Book b1 = new Book { Title = "Essential C# 5.0", Publisher = "Addison Wesley" };
            Book b1Copy = bookstore.AddBook(b1);
            Assert.AreEqual(4, b1Copy.Id);
            Assert.AreEqual("Essential C# 5.0", b1Copy.Title);
            b1Copy.Title = "Strange title";
            Assert.AreEqual(4, bookstore.GetBooks().Count);
            Book updatedBook = bookstore.UpdateBook(b1Copy.Id.ToString(), b1Copy);
            Assert.AreEqual("Strange title", updatedBook.Title);

            Book bCopy2 = bookstore.DeleteBook("2");
            Assert.AreEqual(2, bCopy2.Id);
            Assert.AreEqual("Beginning Android 4 Application Development", bCopy2.Title);

            Assert.AreEqual(3, bookstore.GetBooks().Count);

            Assert.IsNull(bookstore.DeleteBook("100"));
        }


    }
}