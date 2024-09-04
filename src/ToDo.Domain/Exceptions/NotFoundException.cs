namespace ToDo.Domain.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException() : base()
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
    public NotFoundException(string resourceType, string resourceIdentifier)
                            : base($"{resourceType} with id: {resourceIdentifier} doesn't exist")
    {

    }
}
