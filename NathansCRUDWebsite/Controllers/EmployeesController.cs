using System;
using Microsoft.AspNetCore.Mvc;
using NathansCRUDWebsite.Models;

namespace NathansCRUDWebsite.Controllers
{
    public class EmployeesController : Controller
    {
       

        public IActionResult Index()
        {
            EmployeeRepo repo = new EmployeeRepo();
            EmployeesViewsModel.Employees = repo.GetEmployees();
            return View();
        }

        public IActionResult UpdatedPage(Employees e)
        {
            EmployeesViewsModel emvm = new EmployeesViewsModel();
            emvm.EmployeesUpdate = e;
            return View(emvm);
        }

     public IActionResult NewEmployee()
        {
            return View();
        }

        public IActionResult CreateEmployee(Employees e)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.CreateEmployees(e);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int idToDelete)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.DeleteEmployee(idToDelete);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee(Employees e)
        {
            EmployeeRepo repo = new EmployeeRepo();
            repo.UpdateEmployee(e);
            return RedirectToAction("Index");
        }
    }
}
