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
    public class AlumnosTbsController : Controller
    {
        private DBAsesoriasFIADEntities db = new DBAsesoriasFIADEntities();

        // GET: AlumnosTbs
        public ActionResult Index()
        {
            return View(db.AlumnosTb.ToList());
        }

        // GET: AlumnosTbs/Details/5
        public ActionResult Details()
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //AlumnosTb alumnosTb = db.AlumnosTb.Find(id);
            //if (alumnosTb == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(alumnosTb);
            return View();
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

        public ActionResult AlumnosCreate()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AlumnosCreate(ExcelViewModel importExcel)
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
                    foreach(DataRow row in table.Rows)
                    {
                        
                        row[0] = Convert.ToInt32(row[0]);
                        row[1] = row[1].ToString();
                        row[2] = row[2].ToString();
                        row[3] = row[3].ToString();
                        row[4] = row[4].ToString();
                    }
                    DataTable newTable = table.Clone();
                    newTable.Columns[0].DataType = typeof(int);
                    newTable.Columns[1].DataType = typeof(string);
                    newTable.Columns[2].DataType = typeof(string);
                    newTable.Columns[3].DataType = typeof(string);
                    newTable.Columns[4].DataType = typeof(string);
                    foreach(DataRow row in table.Rows)
                    {
                        newTable.ImportRow(row);
                    }
                    
                    foreach(DataRow row in newTable.Rows)
                    {
                        db.SP_AgregarAlumno(Convert.ToInt32(row[0]),row[1].ToString(),row[2].ToString(), row[3].ToString(), row[4].ToString());
                    }
                }
            }

            return View();
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
