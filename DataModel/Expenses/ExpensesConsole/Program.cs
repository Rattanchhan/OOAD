namespace ExpensesConsole;
using ExpensesLibray;
class Program
{
    static void Main(string[] args)
    {
         List<Expense> expenses = new List<Expense>()
        {
            new Expense
            {
                No=1,Description="Studying",Amount=200
            },
            new Expense
            {
                No=2,Description="Gym",Amount=300
            },
            new Expense
            {
                No=3,Description="Sport",Amount=400
            },
            new Expense
            {
                No=4,Description="Game",Amount=500
            }
        };

        try
        {
            string fileName = "expense.txt";
            ExpenseTask expenseTask = new(fileName);

            // expenseTask.WriteIntoFile(expenses);

            expenseTask.ReadFromFile();

            Console.WriteLine($"Toatal Amount: {expenseTask.GetTotalAmount()}");
            Console.WriteLine($"Max Amount: {expenseTask.GetMaxAmount()}");

        }
        catch (Exception exception)
        {
            exception.Message.ToString();
        }
        }
    }
