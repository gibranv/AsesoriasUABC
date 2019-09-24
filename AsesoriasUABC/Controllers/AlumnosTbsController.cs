using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsesoriasUABC.Models;

namespace AsesoriasUABC.Controllers
{
    public class AlumnosTbsController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: AlumnosTbs
        public ActionResult Index()
        {
            return View(db.AlumnosTb.ToList());
        }

        // GET: AlumnosTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnosTb alumnosTb = db.AlumnosTb.Find(id);
            if (alumnosTb == null)
            {
                return HttpNotFound();
            }
            return View(alumnosTb);
        }

        // GET: AlumnosTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlumnosTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Alumno,matricula,nombre,apellidoP,apellidoM,idCarrera,grupo")] AlumnosTb alumnosTb)
        {
            if (ModelState.IsValid)
            {
                db.AlumnosTb.Add(alumnosTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumnosTb);
        }

        // GET: AlumnosTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnosTb alumnosTb = db.AlumnosTb.Find(id);
            if (alumnosTb == null)
            {
                return HttpNotFound();
            }
            return View(alumnosTb);
        }

        // POST: AlumnosTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Alumno,matricula,nombre,apellidoP,apellidoM,idCarrera,grupo")] AlumnosTb alumnosTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnosTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumnosTb);
        }

        // GET: AlumnosTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnosTb alumnosTb = db.AlumnosTb.Find(id);
            if (alumnosTb == null)
            {
                return HttpNotFound();
            }
            return View(alumnosTb);
        }

        // POST: AlumnosTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnosTb alumnosTb = db.AlumnosTb.Find(id);
            db.AlumnosTb.Remove(alumnosTb);
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
