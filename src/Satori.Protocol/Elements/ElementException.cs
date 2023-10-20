namespace Satori.Protocol.Elements;

public class ElementException : Exception
{
    private ElementException(string message) : base(message)
    {
    }

    internal static ElementException TagNameIsNull(Type type)
    {
        return new ElementException($"The TagName property of {type.Name} is null.");
    }
}