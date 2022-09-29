using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDetails;

namespace StudentDetails.Controllers
{
    public class tblStudentInfoesController : Controller
    {
        private StudentDBEntities db = new StudentDBEntities();

        // GET: tblStudentInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.tblStudentInfoes.ToListAsync());
        }

        // GET: tblStudentInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblStudentInfo = await db.tblStudentInfoes.FindAsync(id);
            if (tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentInfo);
        }

        // GET: tblStudentInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblStudentInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,studentName,studentMobile,studentAddress,studentDept")] tblStudentInfo tblStudentInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblStudentInfoes.Add(tblStudentInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblStudentInfo);
        }

        // GET: tblStudentInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblStudentInfo = await db.tblStudentInfoes.FindAsync(id);
            if (tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentInfo);
        }

        // POST: tblStudentInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentId,studentName,studentMobile,studentAddress,studentDept")] tblStudentInfo tblStudentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudentInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblStudentInfo);
        }

        // GET: tblStudentInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblStudentInfo = await db.tblStudentInfoes.FindAsync(id);
            if (tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentInfo);
        }

        // POST: tblStudentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblStudentInfo tblStudentInfo = await db.tblStudentInfoes.FindAsync(id);
            db.tblStudentInfoes.Remove(tblStudentInfo);
            await db.SaveChangesAsync();
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
