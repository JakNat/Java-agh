package appl;

import excp.BadInputException;
import excp.NothingToSubstractFromException;
import excp.TooBigNumberException;

public abstract class Calculator
{
    abstract void SaveToFile(String x, String filename);
    abstract String Add(String x);
    abstract String Substract(String x) throws NothingToSubstractFromException, BadInputException;
    abstract String Multiply(int x) throws TooBigNumberException;
}


