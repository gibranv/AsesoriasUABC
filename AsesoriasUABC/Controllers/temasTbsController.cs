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
    public class temasTbsController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: temasTbs
        public ActionResult Index()
        {
            return View(db.temasTb.ToList());
        }

        // GET: temasTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temasTb temasTb = db.temasTb.Find(id);
            if (temasTb == null)
            {
                return HttpNotFound();
            }
            return View(temasTb);
        }

        // GET: temasTbs/Create
        public ActionResult Create()
        {
            ViewBag.id_Materias = new SelectList(db.MateriasTb.ToList(),"id_materia","nombre");
            return View();
        }

        // POST: temasTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Temas,numero_tema,nombre_tema")] temasTb temasTb)
        {
            if (ModelState.IsValid)
            {

                db.temasTb.Add(temasTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Materias = new SelectList(db.MateriasTb.ToList(), "id_materia", "nombre");
            return View(temasTb);
        }

        // GET: temasTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            temasTb temasTb = db.temasTb.Find(id);
            if (temasTb == null)
            {
                
                return HttpNotFound();
            }
            ViewBag.id_Materias = new SelectList(db.MateriasTb.ToList(), "id_materia", "nombre", temasTb.id_Materias);
            return View(temasTb);
        }

        // POST: temasTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Temas,numero_tema,nombre_tema")] temasTb temasTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temasTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Materias = new SelectList(db.MateriasTb.ToList(), "id_materia", "nombre", temasTb.id_Materias);
            return View(temasTb);
        }

        // GET: temasTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            temasTb temasTb = db.temasTb.Find(id);
            if (temasTb == null)
            {
                return HttpNotFound();
            }
            return View(temasTb);
        }

        // POST: temasTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            temasTb temasTb = db.temasTb.Find(id);
            db.temasTb.Remove(temasTb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public bool validado (temasTb tema)
        {

            return false;
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
