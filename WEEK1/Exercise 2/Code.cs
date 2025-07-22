using System;

public class Product : IComparable<Product>
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public int CompareTo(Product other)
    {
        return ProductId.CompareTo(other.ProductId);
    }

    public override string ToString()
    {
        return $"{ProductId}: {ProductName} ({Category})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product[] products = new Product[]
        {
            new Product { ProductId = 105, ProductName = "Laptop", Category = "Electronics" },
            new Product { ProductId = 102, ProductName = "Shoes", Category = "Footwear" },
            new Product { ProductId = 101, ProductName = "Phone", Category = "Electronics" },
            new Product { ProductId = 104, ProductName = "Watch", Category = "Accessories" },
            new Product { ProductId = 103, ProductName = "Book", Category = "Education" }
        };

        Console.Write("Enter Product ID to search: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("\n--- Linear Search ---");
        Product result1 = LinearSearch(products, id);
        if (result1 != null)
            Console.WriteLine("Result: " + result1.ToString());
        else
            Console.WriteLine("Product not found.");

        Console.WriteLine("Time Complexity of Linear Search:");
        Console.WriteLine("Best Case: O(1), Average Case: O(n), Worst Case: O(n)");

        Array.Sort(products);

        Console.WriteLine("\n--- Binary Search ---");
        Product result2 = BinarySearch(products, id);
        if (result2 != null)
            Console.WriteLine("Result: " + result2.ToString());
        else
            Console.WriteLine("Product not found.");

        Console.WriteLine("Time Complexity of Binary Search:");
        Console.WriteLine("Best Case: O(1), Average Case: O(log n), Worst Case: O(log n)");

        Console.WriteLine("\n--- Analysis ---");
        Console.WriteLine("Linear Search works on unsorted data but is slower on large datasets.");
        Console.WriteLine("Binary Search is faster (logarithmic time) but requires sorted data.");
        Console.WriteLine("➡ For large e-commerce platforms, Binary Search is more efficient.");
    }

    static Product LinearSearch(Product[] products, int id)
    {
        foreach (var product in products)
        {
            if (product.ProductId == id)
                return product;
        }
        return null;
    }

    static Product BinarySearch(Product[] products, int id)
    {
        int left = 0, right = products.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (products[mid].ProductId == id)
                return products[mid];
            else if (products[mid].ProductId < id)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return null;
    }
}
