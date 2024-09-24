using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace review
{
    internal class Program
    {
        //Invoking methods to handle required tasks in a console project
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
                Task task = new(fileName);

                // task.WriteIntoFile(expenses);

                task.ReadFromFile();

                Console.WriteLine($"Toatal Amount: {task.GetTotalAmount()}");
                Console.WriteLine($"Max Amount: {task.GetMaxAmount()}");

            }
            catch (Exception exception)
            {
                exception.Message.ToString();
            }
        }
    }


    //Creating methods to handle required tasks
    public class Task
    {
        public List<Expense>? expenses;
        public string fileName=string.Empty;
        public Task(string fileName)
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

    //Create data model representing every expense
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
}
