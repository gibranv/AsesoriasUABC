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
    public class AsesoresTbsController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: AsesoresTbs
        public ActionResult Index()
        {
            return View(db.AsesoresTb.ToList());
        }

        // GET: AsesoresTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoresTb asesoresTb = db.AsesoresTb.Find(id);
            if (asesoresTb == null)
            {
                return HttpNotFound();
            }
            return View(asesoresTb);
        }

        // GET: AsesoresTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsesoresTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Asesores,nombre,ApellidoP,codigo_empleado,correo,contraseña,sexo,ApellidoM")] AsesoresTb asesoresTb)
        {
            if (ModelState.IsValid)
            {
                db.AsesoresTb.Add(asesoresTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesoresTb);
        }

        // GET: AsesoresTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoresTb asesoresTb = db.AsesoresTb.Find(id);
            if (asesoresTb == null)
            {
                return HttpNotFound();
            }
            return View(asesoresTb);
        }

        // POST: AsesoresTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Asesores,nombre,ApellidoP,codigo_empleado,correo,contraseña,sexo,ApellidoM")] AsesoresTb asesoresTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asesoresTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asesoresTb);
        }

        // GET: AsesoresTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoresTb asesoresTb = db.AsesoresTb.Find(id);
            if (asesoresTb == null)
            {
                return HttpNotFound();
            }
            return View(asesoresTb);
        }

        // POST: AsesoresTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsesoresTb asesoresTb = db.AsesoresTb.Find(id);
            db.AsesoresTb.Remove(asesoresTb);
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
