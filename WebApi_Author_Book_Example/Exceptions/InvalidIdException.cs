namespace WebApi_Author_Book_Example.Exceptions
{
    public class AuthorNotFoundException:Exception
    {
        public AuthorNotFoundException(string message):base(message) { }
    }
}
