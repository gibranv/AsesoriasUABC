using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsesoriasUABC.Models;

using AsesoriasUABC.ViewModels;

namespace AsesoriasUABC.Controllers
{
    public class AsesoriasTbsController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: AsesoriasTbs
        public ActionResult Index()
        {
            return View(db.AsesoriasTb.ToList());
        }

        // GET: AsesoriasTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoriasTb asesoriasTb = db.AsesoriasTb.Find(id);
            if (asesoriasTb == null)
            {
                return HttpNotFound();
            }
            return View(asesoriasTb);
        }

        // GET: AsesoriasTbs/Create
        public ActionResult Create()
        {

            List<MateriasTb> lstMaterias = db.MateriasTb.ToList();
            List<temasTb> lstTemas = db.temasTb.ToList();
            List<AsesoresTb> lstAsesores = db.AsesoresTb.ToList();
            
            ViewBag.LstMateria = new SelectList(lstMaterias, "id_materia", "nombre");
            ViewBag.LstTema = new SelectList(lstTemas, "id_Temas", "nombre_tema");
            ViewBag.LstAsesor = new SelectList(lstAsesores, "Id_Asesores", "nombre");
            return View();
        }

        // POST: AsesoriasTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AsesoriaModelView ase)
        {
            List<MateriasTb> lstMaterias = db.MateriasTb.ToList();
            List<temasTb> lstTemas = db.temasTb.ToList();
            List<AsesoresTb> lstAsesores = db.AsesoresTb.ToList();
            ViewBag.LstMateria = new SelectList(lstMaterias, "id_materia", "nombre");
            ViewBag.LstTema = new SelectList(lstTemas, "id_Temas", "nombre_tema");
            ViewBag.LstAsesor = new SelectList(lstAsesores, "Id_Asesores", "nombre");

            if (ModelState.IsValid)
            {
                AsesoriasTb dbase = new AsesoriasTb();
                dbase.cvc = ase.cvc.ToString();
                dbase.matricula = ase.matricula;
                dbase.id_materia = ase.id_materia;
                dbase.id_asesor = ase.id_asesor;
                dbase.time = "24/09/2019";
                db.AsesoriasTb.Add(dbase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           return View(ase);
        }

        // GET: AsesoriasTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoriasTb asesoriasTb = db.AsesoriasTb.Find(id);
            if (asesoriasTb == null)
            {
                return HttpNotFound();
            }
            return View(asesoriasTb);
        }

        // POST: AsesoriasTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_asesoria,matricula,id_materia,id_asesor,cvc,time")] AsesoriasTb asesoriasTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asesoriasTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asesoriasTb);
        }

        public ActionResult FindAlumno(string m)
        {
            int matricula = Convert.ToInt32(m);
            AlumnosTb alumno = new AlumnosTb();
            alumno = (AlumnosTb)db.AlumnosTb.Where(i => i.matricula == matricula).FirstOrDefault();

            var result = new { status = "Succes", name = alumno.nombre + alumno.apellidoP + alumno.apellidoM, carrera = alumno.idCarrera };
            return Json(result,JsonRequestBehavior.AllowGet);
        }


        // GET: AsesoriasTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoriasTb asesoriasTb = db.AsesoriasTb.Find(id);
            if (asesoriasTb == null)
            {
                return HttpNotFound();
            }
            return View(asesoriasTb);
        }

        // POST: AsesoriasTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsesoriasTb asesoriasTb = db.AsesoriasTb.Find(id);
            db.AsesoriasTb.Remove(asesoriasTb);
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
