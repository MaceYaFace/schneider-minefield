namespace Minefield.Exceptions;

public class OutOfLivesException(string errMessage = "Out of lives") : Exception(errMessage);