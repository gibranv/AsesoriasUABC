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
using ExcelDataReader;
using System.IO;

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
        public ActionResult Create(ExcelViewModel importExcel)
        {
            string path = Server.MapPath("~/Content/Upload/" + importExcel.file.FileName);
            importExcel.file.SaveAs(path);
            using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    // Ejemplos de acceso a datos
                    DataTable table = result.Tables[0];
                    DataRow clave_materia = table.Rows[0];
                    DataRow plan_de_estudios = table.Rows[1];
                    DataRow nombre = table.Rows[3];
                    List<DataRow> temas = new List<DataRow>();
                    int i = 4;
                    do
                    {
                        temas.Add(table.Rows[i]);
                        i++;
                    } while (i < table.Rows.Count );
                    //Agregando materias a la base de datos
                     var id_materia = db.SP_AgregarMateria(nombre[0].ToString(),Convert.ToInt32(clave_materia[0]),plan_de_estudios[0].ToString()).FirstOrDefault();

                    //Agregando temas a la base de datos
                    foreach (DataRow tema in temas)
                    {
                        db.SP_AgregarTema(tema[0].ToString(), tema[1].ToString(), id_materia);
                    }


                }
            }
            return View();
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
