namespace ExpensesLibray;

public class Expense
{
     public int No { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }


        public override string ToString()
        {
            return $"No: {No}, Description: {Description}, Amount: {Amount}";
        }
}