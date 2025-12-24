using FinanceApp.Data.Service;
using FinanceApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceApp.Controllers
{
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        
        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var expenses = await _expensesService.GetAllByUser(userId!);
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            ModelState.Remove("UserId");
            
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //    foreach (var error in errors)
            //    {
            //        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
            //    }
            //}
            
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Console.WriteLine($"Saving expense for user: {userId}");
                expense.UserId = userId!;
                await _expensesService.Add(expense);
                Console.WriteLine("Expense saved successfully");
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        public IActionResult GetChart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _expensesService.GetChartDataByUser(userId!);
            return Json(data);
        }
    }
}