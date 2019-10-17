using data.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Public.Controllers
{
    
    public class HomeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult employee()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Employee([Bind(Include = "Id,Name,Age,Phone,Email,Date")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("employee");
            }

            return View(employee);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}