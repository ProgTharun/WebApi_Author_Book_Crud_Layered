namespace WebApi_Author_Book_Example.Model
{
    public class ErrorResponse
    {
        public int Statuscode { get; set; }

        public string ExceptionMessage { get; set; }
        public string Title { get; set; }
    }
}
