using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Linq;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = _context.Employees.Find(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            _context.Employees.Update(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            _context.Employees.Remove(emp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
