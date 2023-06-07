namespace Core.Exceptions
{
    public class NotFoundException : CustomBaseException
    {
        public NotFoundException(string? message = "Not Found Error !") : base("Not Found", message) { }
        public NotFoundException(Type type) : base("Not Found", $"{type.Name} Not Found") { }
    }
}
