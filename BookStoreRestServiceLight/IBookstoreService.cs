using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BookStoreRestServiceLight
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookstoreService" in both code and config file together.
    [ServiceContract]
    public interface IBookstoreService
    {
        [OperationContract]   
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "books")]
        IList<Book> GetBooks();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "books/{id}")]
        Book GetBook(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "books/{id}/title")]
        string GetBookTitle(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "books/title/{titleFragment}")]
        IEnumerable<Book> GetBooksByTite(string titleFragment);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "books")]
        Book AddBook(Book book);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "books/{id}")]
        Book UpdateBook(string id, Book book);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            //RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "books/{id}")]
        Book DeleteBook(string id);
    }
}