using DummyBudgets.Models;
using Microsoft.EntityFrameworkCore;

namespace DummyBudgets.Data
{
    public class BudgetDbContext : DbContext
    {
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }
    }
}
