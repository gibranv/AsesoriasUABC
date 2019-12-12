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
    [Authorize(Roles = "Administrador,Director,Subdirector,Profesor,Coordinador")]
    public class carrerasController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: carreras
        public ActionResult Index()
        {
            return View(db.carreras.ToList());
        }

        // GET: carreras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carreras carreras = db.carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        // GET: carreras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_carrera,codigo,nombre")] carreras carreras)
        {
            if (ModelState.IsValid)
            {
                db.carreras.Add(carreras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carreras);
        }

        // GET: carreras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carreras carreras = db.carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        // POST: carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_carrera,codigo,nombre")] carreras carreras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carreras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carreras);
        }

        // GET: carreras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carreras carreras = db.carreras.Find(id);
            if (carreras == null)
            {
                return HttpNotFound();
            }
            return View(carreras);
        }

        // POST: carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carreras carreras = db.carreras.Find(id);
            db.carreras.Remove(carreras);
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
