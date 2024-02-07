using DummyBudgets.Data;
using DummyBudgets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DummyBudgets.Controllers
{
    public class BudgetController : Controller
    {
        private readonly BudgetDbContext _dbContext;

        public BudgetController(BudgetDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var budgets = _dbContext.Budgets.Include(b => b.Expenses).ToList();
            return View(budgets);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Budgets.Add(budget);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }
    }
}
