using System.Text.Json;

namespace ExpensesLibray;
public class ExpenseTask
{
    public List<Expense>? expenses;
    public string fileName=string.Empty;
    public ExpenseTask(string fileName)
    {
        this.fileName = fileName;
    }
    public void ReadFromFile()
    {
        try
        {
            string getData = File.ReadAllText(fileName);
            expenses = JsonSerializer.Deserialize<List<Expense>>(getData) ?? null;
            Console.WriteLine("JSON read from file successfully!");
        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
    }
    public void WriteIntoFile(List<Expense> expenses)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(expenses,new JsonSerializerOptions { WriteIndented=true});
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("JSON written to file successfully!");

        }catch(Exception exception)
        {
            exception.Message.ToString();
        }
        
    }
        public double GetTotalAmount()
    {
        return expenses?.Sum(expense => expense.Amount)??0;
    }

    public Expense? GetMaxAmount()
    {
        return expenses?.FirstOrDefault(expense => expense.Amount == (expenses?.Max(rexpense => rexpense.Amount)))??null;
    }
}