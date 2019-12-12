using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsesoriasUABC.Models;
using System.Collections;
using AsesoriasUABC.ViewModels;

namespace AsesoriasUABC.Controllers
{
    [Authorize(Roles = "Administrador,Director,Subdirector,Profesor,Coordinador")]
    public class AsesoresController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: Asesores
        public ActionResult Index()
        {
            return View(db.AsesoresTb.ToList());
        }

        // GET: Asesores/Details/5
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

        // GET: Asesores/Create
        public ActionResult Create()
        {
            SelectListItem selListItem = new SelectListItem() { Value = "Hombre", Text = "Hombre" };
            SelectListItem selListItem2 = new SelectListItem() { Value = "Mujer", Text = "Mujer" };
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(selListItem);
            lst.Add(selListItem2);
            ViewBag.sexo = new SelectList(lst,"Value","Text");
            return View();
        }

        // POST: Asesores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Asesores,nombre,ApellidoP,codigo_empleado,correo,sexo,ApellidoM")] AsesoresTb asesoresTb)
        {
            if (ModelState.IsValid)
            {
                db.AsesoresTb.Add(asesoresTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asesoresTb);
        }

        // GET: Asesores/Edit/5
        public ActionResult Edit(int? id)
        {
            
            List<Grupos> lstGrupos = db.Grupos.ToList();
            List<MateriasTb> lstMaterias = db.MateriasTb.ToList();
            ViewBag.LstMaterias = new SelectList(lstMaterias, "id_materia", "nombre");
            ViewBag.LstGrupos = new SelectList(lstGrupos, "id_grupo", "num_grupo");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsesoresTb asesoresTb = db.AsesoresTb.Find(id);
            if (asesoresTb == null)
            {
                return HttpNotFound();
            }
            AsesoresViewModel ase = new AsesoresViewModel(asesoresTb);
            
            return View(ase);
        }

        // POST: Asesores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AsesoresViewModel ase)
        {
            List<Grupos> lstGrupos = db.Grupos.ToList();
            List<MateriasTb> lstMaterias = db.MateriasTb.ToList();
            ViewBag.LstMaterias = new SelectList(lstMaterias, "id_materia", "nombre");
            ViewBag.LstGrupos = new SelectList(lstGrupos, "id_grupo", "num_grupo");
            if (ModelState.IsValid)
            {
              
                Materias_Grupos mg = new Materias_Grupos();
                mg.id_grupo = Convert.ToInt32(ase.LstGrupos);
                mg.id_asesor = ase.Id_Asesores;
                mg.id_materia = Convert.ToInt32(ase.LstMaterias);
                db.Materias_Grupos.Add(mg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ase);
        }

        // GET: Asesores/Delete/5
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

        // POST: Asesores/Delete/5
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
