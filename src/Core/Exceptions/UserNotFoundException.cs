namespace EvalApi.Src.Core.Exceptions;
public class UserNotFoundException : Exception
{
    public UserNotFoundException(int userId)
        : base($"User with id={userId} not found.")
    {
    }
}