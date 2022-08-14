using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBMS_PROJECT.Models;

namespace DBMS_PROJECT.Controllers
{
  
    public class BookIssuesController : Controller
    {
        private Library_Management_SystemEntities db = new Library_Management_SystemEntities();

        
        
        // GET: BookIssues
        public ActionResult Index()
        {
            var bookIssues = db.BookIssues.Include(b => b.Book).Include(b => b.Faculty).Include(b => b.Student);
            return View(bookIssues.ToList());
        }

        // GET: BookIssues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // GET: BookIssues/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookTitle");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: BookIssues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookIssueID,BookID,StudentID,FacultyID,BookAvailable,Fine,ReturnDate,IssueDate")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.BookIssues.Add(bookIssue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookTitle", bookIssue.BookID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", bookIssue.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", bookIssue.StudentID);
            return View(bookIssue);
        }


        public ActionResult Create_Faculty()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookTitle");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: BookIssues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Faculty([Bind(Include = "BookIssueID,BookID,StudentID,FacultyID,BookAvailable,Fine,ReturnDate,IssueDate")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.BookIssues.Add(bookIssue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookTitle", bookIssue.BookID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", bookIssue.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", bookIssue.StudentID);
            return View(bookIssue);
        }

        // GET: BookIssues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookTitle", bookIssue.BookID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", bookIssue.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", bookIssue.StudentID);
            return View(bookIssue);
        }

        // POST: BookIssues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookIssueID,BookID,StudentID,FacultyID,BookAvailable,Fine,ReturnDate,IssueDate")] BookIssue bookIssue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookIssue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "BookTitle", bookIssue.BookID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", bookIssue.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", bookIssue.StudentID);
            return View(bookIssue);
        }

        // GET: BookIssues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookIssue bookIssue = db.BookIssues.Find(id);
            if (bookIssue == null)
            {
                return HttpNotFound();
            }
            return View(bookIssue);
        }

        // POST: BookIssues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookIssue bookIssue = db.BookIssues.Find(id);
            db.BookIssues.Remove(bookIssue);
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
