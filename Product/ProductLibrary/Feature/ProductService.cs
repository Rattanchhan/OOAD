namespace ProductLibrary.Feature;

using ProductLibrary.Feature.dto;
using ProductLibrary.Extension;
using ProductLibrary.Model;
using System.Text.Json;
using System.Runtime.CompilerServices;

public class ProductService
{
    private List<Product>? products = new List<Product>();
    public ProductService(){
        this.products = ProductRepository.RedirectLoad();
    }
    public List<Product>? GetProducts(){
        return products;
    }

    public string? Create(ProductRequest productRequest)
    {
        //Validat product code
        if(products!=null){
            if(products.Exists(product=> product.Code == productRequest.Code.Trim())){
                return "Product has bean ready existing...";
            }
            else{
                products.Add(productRequest.ToEntity());
            }
        }
        else{
            products?.Add(productRequest.ToEntity());
        }
        ProductRepository.Save(products);
        return "Created Successfully...";
    }

    public List<ProductResponse>? GetAll()
    {
        products=ProductRepository.GetAll();
        if(products==null){
            return new List<ProductResponse>();
        }
        else{
            return products.Select(product=>product.ToResponse()).ToList();
        }
    }

    public ProductResponse? Get(string key)
    {
       return products?.Find(product=>product.Code==key)?.ToResponse();
    }
    public string? Update(ProductRequest productRequest)
    {
        var category = Category.None;

        //Validat product code
        if(products!=null){
            Product? product = products.Find(product=>product.Code==productRequest.Code);
            if(product==null){
                return "Product has not been found...";
            }
            else{
                //Remove
                products.Remove(product);

                Category.TryParse(productRequest.Category, out category);
                product.Name=productRequest.Name;
                product.Category=category;

                //Save to products
                products.Add(product);
                Save();
            }
        }
        else{
            return "Product List empty...";
        }
        return "Updated Successfully...";
    }

    public void Save(){
        ProductRepository.Save(products);
    }
}