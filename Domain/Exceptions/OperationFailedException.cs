namespace Domain.Exceptions;

public class OperationFailedException(string message) : Exception(message);