namespace Core.Exceptions
{
    public class BadRequestException : CustomBaseException
    {
        public BadRequestException(string? message = "Bad Request Exception !") : base("Bad Request", message) { }
    }
}
