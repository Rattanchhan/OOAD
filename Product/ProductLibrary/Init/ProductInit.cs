namespace ProductLibrary.Init;
using ProductLibrary.Model;
public static class ProductInit{
    public static List<Product>? ProductInitialize = new List<Product>()
    {
        new()
        {
            Id=Guid.NewGuid().ToString(),
            Code = "PRD001",
            Name = "Coca",
            Category= Category.Drink,
            Created=DateTime.Now
        },
        new()
        {
            Id=Guid.NewGuid().ToString(),
            Code = "PRD002",
            Name = "Dream 125",
            Category= Category.Vehicle,
            Created=DateTime.Now
        },
        new()
        {
            Id=Guid.NewGuid().ToString(),
            Code = "PRD003",
            Name = "TShirt-SEA game 2023",
            Category= Category.Cloth,
            Created=DateTime.Now
        }
    };
}