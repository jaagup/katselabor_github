using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using katselabor.Interfaces;
using katselabor.Models;
using katselabor.Repos;
using System.Web.Mvc;

namespace katselabor
{
    public class studentsController : Controller
    {
        private katselaborEntities db = new katselaborEntities();

        // GET: students
        public ActionResult Index()
        {
            return View(db.students.ToList());
        }

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: students/Create
        public ActionResult Create()
        {

            students model = new students();
            model.entryDate = DateTime.Now;

            return View(model);
        }

        // POST: students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,length,mass,sex,entryDate")] students students)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,length,mass,sex,entryDate")] students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: students/search/myname
        public ActionResult Search(string id)
        {
            SearchModel model = new SearchModel();


            IStudentsRepo repo = new StudentRepo();
            IList<students> resultSet = repo.getAllStudentsByName(id);

            model.resultSet = resultSet;

            if (id == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            students students = db.students.Find(id);
            db.students.Remove(students);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
