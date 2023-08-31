using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_CRUD_MVC.Models;

namespace Student_CRUD_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration configuration;
        private StudentCRUD crud;
        public StudentController(IConfiguration configuration)
        {
             this.configuration = configuration;
            crud = new StudentCRUD(this.configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var model = crud.GetStudents();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int roll)
        {
            var result = crud.GetStudentById(roll);
            return View(result);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int result = crud.AddStudent(student);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int roll)
        {
            var result = crud.GetStudentById(roll);
            return View(result);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int result = crud.UpdateStudent(student);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int roll)
        {
            var result = crud.DeleteStudent(roll);
            return View(result);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int roll)
        {
            try
            {
                int result = crud.DeleteStudent(roll);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
