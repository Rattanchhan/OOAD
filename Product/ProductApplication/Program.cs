using ProductLibrary.Feature;
using ProductLibrary.Feature.dto;
using ProductLibrary.Model;

namespace ProductApplication;

class Program
{
    private static ProductService productService = new ProductService();
    // private static List<ProductResponse>? listProductResponse;
    static void Main(string[] args)
    {
        List<Product>? list = productService.GetProducts();
        ProductRequest productRequest  =new ProductRequest
        {
            Code="Test-123",
            Name="Test",
            Category="Cloth"
        };

        //Create new product

        // productService.Create(productRequest);


        // if(list!=null){
        //     for (int i = 0; i < list.Count; i++)
        //     {
        //         Product product = list[i];
        //         Console.WriteLine($"\n {product.Code}");
        //     }
        // }

        //Save to file

        // productService.Save();

        //Reload from file

        // listProductResponse = productService.GetAll();
        Console.WriteLine($"{productService.Update(productRequest)}");
        ProductResponse? productResponse;
        productResponse=productService.Get("Test-123");

        Console.WriteLine($"\n {productResponse?.Code}");
        Console.WriteLine($"\n {productResponse?.Name}");
        Console.WriteLine($"\n {productResponse?.Category}");

        // if(listProductResponse!=null){
        //     for (int i = 0; i < listProductResponse.Count; i++)
        //     {
        //         ProductResponse product = listProductResponse[i];
        //         Console.WriteLine($"\n {product.Code}");
        //         Console.WriteLine($"\n {product.Name}");
        //         Console.WriteLine($"\n {product.Category}");
        //         Console.WriteLine();
        //     }
        // }
    }
}
