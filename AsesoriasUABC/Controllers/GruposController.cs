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
    public class GruposController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: Grupos
        public ActionResult Index()
        {
            var grupos = db.Grupos.Include(g => g.carreras);
            return View(grupos.ToList());
        }

        // GET: Grupos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            return View(grupos);
        }

        // GET: Grupos/Create
        public ActionResult Create()
        {
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre");
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_grupo,id_carrera,num_grupo")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                db.Grupos.Add(grupos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre", grupos.id_carrera);
            return View(grupos);
        }

        // GET: Grupos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre", grupos.id_carrera);
            return View(grupos);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_grupo,id_carrera,num_grupo")] Grupos grupos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_carrera = new SelectList(db.carreras, "id_carrera", "nombre", grupos.id_carrera);
            return View(grupos);
        }

        // GET: Grupos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupos grupos = db.Grupos.Find(id);
            if (grupos == null)
            {
                return HttpNotFound();
            }
            return View(grupos);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupos grupos = db.Grupos.Find(id);
            db.Grupos.Remove(grupos);
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
