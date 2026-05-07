// using System.Runtime.InteropServices;

string greeting = "Welcome to Reductio and Absurdum!";

List<Product> products = new List<Product>()
{
    new Product() { 
        Name = "Cloak of Displacement", 
        Price = 250.00m, 
        Available = true, 
        DateAdded = DateTime.Now.AddDays(-10), 
        ProductTypeId = 1 
    },
    new Product() { 
        Name = "Potion of Healing",
        Price = 75.50m, 
        Available = true, 
        DateAdded = DateTime.Now.AddDays(-3), 
        ProductTypeId = 2 
    },
    new Product() { 
        Name = "Immovable Rod", 
        Price = 500.00m, 
        Available = false, 
        DateAdded = DateTime.Now.AddDays(-30), 
        ProductTypeId = 3 
    },
    new Product() { 
        Name = "Wand of Magic Missles", 
        Price = 999.99m, 
        Available = true, 
        DateAdded = DateTime.Now.AddDays(-1), 
        ProductTypeId = 4 
    }
};

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType() { 
        Id = 1, 
        Name = "apparel"
        },
    new ProductType() { 
        Id = 2, 
        Name = "potions"
        },
    new ProductType() { 
        Id = 3, 
        Name = "enchanted objects"
        },
    new ProductType() { 
        Id = 4, 
        Name = "wands"
        }            
};

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
    0. Exit
    1. View All Products
    2. View Products for Category
    3. Add a Product to Inventory
    4. Delete a Product from Inventory
    5. Update a Product's details.");

    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }

    else if (choice == "1")
    {
        ListProducts(products, productTypes);
    }

    else if (choice == "2")
    {
        ViewProductByCategory(products, productTypes);
    }

    else if (choice == "3")
    {
        AddProduct();
    }
    
    else if (choice == "4")
    {
        DeleteProduct();
    }

    else if (choice == "5")
    {
        UpdateProduct();
    }
    else
    {
        Console.WriteLine("Unknown input. Please select a value of 0-5.");
    }
}

void ListProducts(List<Product> products, List<ProductType> productTypes )
{
    Console.WriteLine("Products");
    string a;
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + products[i].Name);
        Console.WriteLine("$"+products[i].Price);

        if (products[i].Available)
        {
            a = "Yes";
        }

        else
        {
            a = "No";
        }

        Console.WriteLine("Available? " + a);
        Console.WriteLine(products[i].DaysOnShelf+" days on shelf");
        ProductType type = productTypes.Find(types => types.Id == products[i].ProductTypeId);

        if (type != null)
        {
            Console.WriteLine("Type: " + type.Name);
        }

        Console.WriteLine();
    }
};

void ViewProductByCategory(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"Choose a Product Type:
    1. Apparel
    2. Potions
    3. Enchanted Objects
    4. Wands");

    choice = Console.ReadLine();
    
    if (choice == "1")
    {
        Console.WriteLine("Apparel");
        Console.WriteLine();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ProductTypeId == 1)
            {
                Console.WriteLine(products[i].Name);
                Console.WriteLine("$" + products[i].Price);
                Console.WriteLine("Available? " + (products[i].Available ? "Yes" : "No"));
                Console.WriteLine(products[i].DaysOnShelf + " days on shelf");
                Console.WriteLine();
            }
        }
    }

    else if (choice == "2")
    {
        Console.WriteLine("Potions");
        Console.WriteLine();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ProductTypeId == 2)
            {
                Console.WriteLine(products[i].Name);
                Console.WriteLine("$" + products[i].Price);
                Console.WriteLine("Available? " + (products[i].Available ? "Yes" : "No"));
                Console.WriteLine(products[i].DaysOnShelf + " days on shelf");
                Console.WriteLine();
            }
        }
    }

    else if (choice == "3")
    {
        Console.WriteLine("Enchanted Objects");
        Console.WriteLine();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ProductTypeId == 3)
            {
                Console.WriteLine(products[i].Name);
                Console.WriteLine("$" + products[i].Price);
                Console.WriteLine("Available? " + (products[i].Available ? "Yes" : "No"));
                Console.WriteLine(products[i].DaysOnShelf + " days on shelf");
                Console.WriteLine();
            }
        }
    }

    else if (choice == "4")
    {
        Console.WriteLine("Wands");
        Console.WriteLine();
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].ProductTypeId == 4)
            {
                Console.WriteLine(products[i].Name);
                Console.WriteLine("$" + products[i].Price);
                Console.WriteLine("Available? " + (products[i].Available ? "Yes" : "No"));
                Console.WriteLine(products[i].DaysOnShelf + " days on shelf");
                Console.WriteLine();
            }
        }
    }

    else
    {
        Console.WriteLine("Unknown input. Please select a value of 1-4.");
    }
};

void AddProduct()
{
    Product newProduct = new Product();
    Console.WriteLine("Enter Product Name:");
    newProduct.Name = Console.ReadLine();

    Console.WriteLine("Enter Product Price:");
    newProduct.Price = decimal.Parse(Console.ReadLine());

    Console.WriteLine(@"Choose a Product Type:
    1. Apparel
    2. Potions
    3. Enchanted Objects
    4. Wands");
    newProduct.ProductTypeId = int.Parse(Console.ReadLine());

    newProduct.Available = true;
    newProduct.DateAdded = DateTime.Now;

    products.Add(newProduct);
    Console.WriteLine(newProduct.Name + " was added.");
    
};

void DeleteProduct()
{
    Console.WriteLine("Select a product to delete:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + products[i].Name);
    }
    
    int selection = int.Parse(Console.ReadLine());

    if (selection >= 1 && selection <= products.Count)
    { 
        products.Remove(products[selection - 1]);
    }

    else
    {
        Console.WriteLine("Invalid selection");
    }
};

void UpdateProduct()
{
    Console.WriteLine("Choose a product to edit");
        for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + products[i].Name);
    }
    int selection = int.Parse(Console.ReadLine());

    if (selection >= 1 && selection <= products.Count)
    {
        Product toUpdate = products[selection - 1];
        Console.WriteLine("Enter Product Name:");
        toUpdate.Name = Console.ReadLine();

        Console.WriteLine("Enter Product Price:");
        toUpdate.Price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Is the product available? (y/n)");
        toUpdate.Available = Console.ReadLine().ToLower() == "y";

        Console.WriteLine(@"Choose a Product Type:
        1. Apparel
        2. Potions
        3. Enchanted Objects
        4. Wands");
        toUpdate.ProductTypeId = int.Parse(Console.ReadLine());
        Console.WriteLine(toUpdate.Name + " was changed.");
    }

    else
    {
        Console.WriteLine("Invalid selection");
    }
};

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }
    public DateTime DateAdded { get; set; }
    public int ProductTypeId { get; set; }
    public int DaysOnShelf 
    {
        get { return (DateTime.Now - DateAdded).Days; }
    }

}
public class ProductType
{
    public int Id {get;  set; }
    public string Name { get; set; }
}