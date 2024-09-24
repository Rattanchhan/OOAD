using System.Text.Json;
using ProductLibrary.Init;
using ProductLibrary.Model;

namespace ProductLibrary.Feature;

public static class ProductRepository{
    public static List<Product>? RedirectLoad(){
      return GetAll()?? ProductInit.ProductInitialize;
    }

    public static void Save(List<Product>? products)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(products,new JsonSerializerOptions { WriteIndented=true});
            File.WriteAllText("proudcts.txt", jsonString);
            Console.WriteLine("JSON written to file successfully!");

        }catch(Exception exception)
        {
            exception.Message.ToString();
        }
    }

    public static List<Product>? GetAll()
    {
        try
        {
            string getProduct = File.ReadAllText("proudcts.txt");
            return JsonSerializer.Deserialize<List<Product>>(getProduct) ?? null;
        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
        return null;
    }
}