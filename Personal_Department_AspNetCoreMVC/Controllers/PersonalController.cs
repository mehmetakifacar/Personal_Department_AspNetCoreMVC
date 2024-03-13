using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Personal_Department_AspNetCoreMVC.Models;

namespace Personal_Department_AspNetCoreMVC.Controllers
{
    public class PersonalController : Controller
    {
        Context db = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var personals = db.PersonalsDb.Include(c => c.Department).ToList();

            return View("Index", personals);
        }



        [HttpGet]
        public IActionResult NewPersonal()
        {
            List<SelectListItem> departments = (from i in db.DepartmentsDb.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.DepartmentName,
                                                    Value = i.DepartmentId.ToString()
                                                }).ToList();
            ViewBag.values = departments;

            return View();
        }



        [HttpPost]
        public IActionResult NewPersonal(Personal p1)
        {
            db.PersonalsDb.Add(p1);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult PersonalUpdate(int id)
        {
            var update = db.PersonalsDb.Find(id);

            return View("PersonalUpdate", update);
        }



        [HttpPost]
        public IActionResult PersonalUpdate(Personal p1)
        {
            var updated = db.PersonalsDb.Find(p1.PersonalId);
            updated.PersonalName = p1.PersonalName;
            updated.PersonalSurname = p1.PersonalSurname;
            updated.PersonalCity = p1.PersonalCity;
            updated.DepartmentId = p1.DepartmentId;
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            var delete = db.PersonalsDb.Find(id);
            db.PersonalsDb.Remove(delete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
