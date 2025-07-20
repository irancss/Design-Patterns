public class ProductFilter
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T item);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Color == _color;
        }
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }
        public bool IsSatisfied(Product item)
        {
            return item.Size == _size;
        }
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatisfied(T item)
        {
            return first.IsSatisfied(item) && second.IsSatisfied(item);
        }
    }

    public class BetterFilter : IFilter<Product>
    {

        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach (var product in items)
            {
                if (specification.IsSatisfied(product))
                {
                    yield return product;
                }
            }
        }
    }
}