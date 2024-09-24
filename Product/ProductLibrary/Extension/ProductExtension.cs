namespace ProductLibrary.Extension;
using ProductLibrary.Feature.dto;
using ProductLibrary.Model;

public static class ProductExtension
{
    public static ProductResponse ToResponse(this Product product)
    {
        return new ProductResponse()
        {
            Id = product.Id,
            Code = product.Code,
            Name = product.Name,
            Category = Enum.GetName<Category>(product.Category)
        };
    }
    public static Product ToEntity(this ProductRequest req)
    {
        var category = Category.None;
        Category.TryParse(req.Category, out category);
        return new Product()
        {
            Id = Guid.NewGuid().ToString(),
            Code = req.Code,
            Name = req.Name,
            Category = category,
            Created = DateTime.Now,
            LastUpdated = null
        };
    }
}

