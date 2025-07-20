
using static ProductFilter;

public class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product("Apple", Color.Green, Size.Small),
            new Product("Tree", Color.Green, Size.Large),
            new Product("House", Color.Blue, Size.Large)
        };
        var bf = new ProductFilter.BetterFilter();
        foreach (var product in bf.Filter(products, new ProductFilter.ColorSpecification(Color.Green)))
        {
            Console.WriteLine($"Product: {product.Name}, Color: Green");
        }

        Console.WriteLine("***********");
        Console.WriteLine("Larg Blue Items");
        foreach (var product in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
        {
            Console.WriteLine(product.Name);
        }
    }
}
