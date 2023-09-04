namespace ProjectForTaqsim.Exceptions;

public class IsNotValidException:Exception
{
    public IsNotValidException(string message) : base($"{message} not is valid") { }
}
