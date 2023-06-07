namespace Core.Exceptions
{
    public class InternalServerException : CustomBaseException
    {
        public InternalServerException(string? message = "Internal Server Exception !") : base("Internal Server", message) { }
    }
}
