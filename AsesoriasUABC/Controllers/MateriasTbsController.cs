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
    public class MateriasTbsController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: MateriasTbs
        public ActionResult Index()
        {
            return View(db.MateriasTb.ToList());
        }

        // GET: MateriasTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriasTb materiasTb = db.MateriasTb.Find(id);
            if (materiasTb == null)
            {
                return HttpNotFound();
            }
            return View(materiasTb);
        }

        // GET: MateriasTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriasTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_materia,nombre,clave_materia,plan_estudios")] MateriasTb materiasTb)
        {
            if (ModelState.IsValid)
            {
                db.MateriasTb.Add(materiasTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materiasTb);
        }

        // GET: MateriasTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriasTb materiasTb = db.MateriasTb.Find(id);
            if (materiasTb == null)
            {
                return HttpNotFound();
            }
            return View(materiasTb);
        }

        // POST: MateriasTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_materia,nombre,clave_materia,plan_estudios")] MateriasTb materiasTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiasTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materiasTb);
        }

        // GET: MateriasTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriasTb materiasTb = db.MateriasTb.Find(id);
            if (materiasTb == null)
            {
                return HttpNotFound();
            }
            return View(materiasTb);
        }

        // POST: MateriasTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MateriasTb materiasTb = db.MateriasTb.Find(id);
            db.MateriasTb.Remove(materiasTb);
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
