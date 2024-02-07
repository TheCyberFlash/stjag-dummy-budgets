namespace DummyBudgets.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }
    }
}
