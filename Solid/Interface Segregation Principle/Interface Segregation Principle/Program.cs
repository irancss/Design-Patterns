
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IFax
{
    void Fax();
}
public class OldPrinter : IPrinter
{
    public void Print() { /* ok */ }
}



public class Demo
{
    static void Main(string[] args)
    {

    }
}