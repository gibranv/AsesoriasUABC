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
            List<Grupos> lstGrupos = db.Grupos.ToList();
            ViewBag.LstMateria = new SelectList(lstMaterias, "id_materia", "nombre");
            ViewBag.LstTema = new SelectList(lstTemas, "id_Temas", "nombre_tema");
            ViewBag.LstAsesor = new SelectList(lstAsesores, "Id_Asesores", "nombre");
            ViewBag.Grupo = new SelectList(lstGrupos, "id_grupo", "num_grupo");
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
            List<Grupos> lstGrupos = db.Grupos.ToList();
            ViewBag.Grupo = new SelectList(lstGrupos, "id_grupo", "num_grupo");
            ViewBag.LstMateria = new SelectList(lstMaterias, "id_materia", "nombre");
            ViewBag.LstTema = new SelectList(lstTemas, "id_Temas", "nombre_tema");
            ViewBag.LstAsesor = new SelectList(lstAsesores, "Id_Asesores", "nombre");

            if (ModelState.IsValid)
            {
                AsesoriasTb dbase = new AsesoriasTb();
                dbase.cvc = nameof(ase.cvc);
                dbase.matricula = ase.matricula;
                dbase.id_materia = ase.id_materia;
                dbase.id_asesor = ase.id_asesor;
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
            var result = new {status = "Not Find",name="", lstGrupos = new SelectList("","")};
            alumno = db.AlumnosTb.Where(i => i.matricula == matricula).FirstOrDefault();
            
            if (alumno != null)
            {
                         
                SelectList lstGrupos = new SelectList(db.SP_GetGruposAlumno(alumno.id_Alumno), "id_grupo", "num_grupo");
                result = new { status = "Succes", name = alumno.nombre +" "+ alumno.apellidoP +" "+ alumno.apellidoM, lstGrupos };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLst(string id_materia)
        {
            int id_m = Convert.ToInt32(id_materia);
            if(db.AlumnosTb.Find( ) != null)
            {

            }
            List<temasTb> lstTemas = db.temasTb.ToList().Where(i => i.id_Materias == id_m).ToList();

            ViewBag.LstTema = new SelectList(lstTemas, "id_Temas", "nombre_tema");
            //ViewBag.LstAsesor = new SelectList(lstAsesores, "Id_Asesores", "nombre");

            return Json(JsonRequestBehavior.AllowGet);
        }

        // GET: AsesoriasTbs/Delete/5
        public ActionResult LstTemasAsesor(string _id_materia,string _id_grupo)
        {
            var id_materia = Convert.ToInt32(_id_materia);
            var id_grupo = Convert.ToInt32(_id_grupo);

            var temas = db.SP_GetTemasMateria(id_materia);
            var asesores = db.SP_GetAsesores(id_materia,id_grupo);
            
            SelectList lstTemas = new SelectList(temas,"Id_Temas","nombre_tema");
            SelectList lstAsesores = new SelectList(asesores, "Id_Asesores", "nombre");
            var result = new { lstTemas, lstAsesores };
            //  ViewBag.LstAsesor = new SelectList(lstAsesores, "Id_Asesores", "nombre");
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult LstMaterias(string _id_Grupo)
        {
            int id_grupo = Convert.ToInt32(_id_Grupo);
            var result = new { status = "Not Find", lstMaterias = new SelectList("", "") };
            SelectList lstMaterias = new SelectList(db.Sp_GetMateriasGrupo(id_grupo), "id_materia", "nombre");
            result = new { status = "", lstMaterias };
            return Json(result);
        }
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
