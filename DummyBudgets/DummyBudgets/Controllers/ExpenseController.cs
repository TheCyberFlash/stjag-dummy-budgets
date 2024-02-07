using DummyBudgets.Data;
using DummyBudgets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DummyBudgets.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly BudgetDbContext _dbContext;

        public ExpenseController(BudgetDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var expenses = _dbContext.Expenses.Include(e => e.Budget).ToList();
            return View(expenses);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            ViewBag.Budgets = _dbContext.Budgets.ToList();
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Expenses.Add(expense);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Budgets = _dbContext.Budgets.ToList();
            return View(expense);
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var expense = _dbContext.Expenses.Include(e => e.Budget).FirstOrDefault(e => e.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }
    }
}
