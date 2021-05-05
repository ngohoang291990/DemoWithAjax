using DemoWithAjax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWithAjax.Controllers
{
    public class StudentController : Controller
    {

        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            //var results = _context.Students.ToList();
            return View();
        }

        public ActionResult GetData()
        {
            var results = _context.Students.ToList();
            return Json(new {Data=results,TotalItems=results.Count},JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int id)
        {
            var item = _context.Students.Find(id);
            return Json(new { data = item },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            if (model.Id > 0)
            {
                _context.Students.Attach(model);
                model.CreatedDate = DateTime.Now;
                //var item = _context.Students.Find(model.Id);
                //item.Name = model.Name;
                //item.Age = model.Age;
                //item.Class = model.Class;
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });
            }
            model.CreatedDate = DateTime.Now;
            _context.Students.Add(model);
            try
            {
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { success = false });
            }
           
        }

        [HttpPost]
        public ActionResult Update(Student request)
        {
            var student = _context.Students.Find(request.Id);
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult DeleteRecord(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            var rs=_context.SaveChanges();
            if (rs > 0)
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}