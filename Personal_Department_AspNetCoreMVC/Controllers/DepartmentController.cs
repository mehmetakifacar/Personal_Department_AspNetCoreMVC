using Microsoft.AspNetCore.Mvc;
using Personal_Department_AspNetCoreMVC.Models;

namespace Personal_Department_AspNetCoreMVC.Controllers
{
    public class DepartmentController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var departments = db.DepartmentsDb.ToList();

            return View("Index", departments);
        }



        [HttpGet]
        public IActionResult NewDepartment()
        {
            return View();
        }



        [HttpPost]
        public IActionResult NewDepartment(Department p1)
        {
            db.DepartmentsDb.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult DepartmentUpdate(int id)
        {
            var update = db.DepartmentsDb.Find(id);

            return View("DepartmentUpdate", update);
        }



        [HttpPost]
        public IActionResult DepartmentUpdate(Department p1)
        {
            var updated = db.DepartmentsDb.Find(p1.DepartmentId);
            updated.DepartmentName = p1.DepartmentName;
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult GetDetails(int id)
        {
            var details = db.PersonalsDb.Where(c => c.DepartmentId == id).ToList();
            var department = db.DepartmentsDb.Where(c => c.DepartmentId == id).
                Select(d => d.DepartmentName).FirstOrDefault();
            ViewBag.value = department;

            return View(details);
        }



        public IActionResult Delete(int id)
        {
            var delete = db.DepartmentsDb.Find(id);
            db.DepartmentsDb.Remove(delete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
