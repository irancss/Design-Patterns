

using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString()
    {
        return $"{nameof(Width)} : {Width} , {nameof(Height)} : {Height}"; 
    }
}
public class Square : Rectangle
{
    public Square(int width, int height) : base(width, height)
    {
    }

    public override int Width
    {
        set { base.Width = base.Height = value; }
    }
    public override int Height
    {
        set { base.Width = base.Height = value; }
    }
}
public class Demo
{
    static public int Area(Rectangle r) => r.Width * r.Height;
    static void Main(string[] args)
    {
        var rectangle = new Rectangle(5, 10);
        var square = new Square(5, 5);
        Console.WriteLine($"Rectangle Area: {Area(rectangle)}");
        Console.WriteLine($"Square Area: {Area(square)}");
    }
}