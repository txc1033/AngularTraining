using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AngularTraining.Controllers
{
    public class EstudiantesController : Controller
    {
        private StudentsContext db = new StudentsContext();

        // GET: Estudiantes
        public ActionResult Index()
        {
            List<Estudiante> estudiantes = db.Estudiante.ToList();


            return View(estudiantes.Take(50));
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estu_idEstudiante,estu_nombre,estu_apellido,estu_cod,estu_curso,estu_profid,estu_sede,estu_region,per_idPersona")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new JsonResult { Data = "Se agrego correctamente"});
                //return RedirectToAction("Index");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new JsonResult { Data = Newtonsoft.Json.JsonConvert.SerializeObject(estudiante) });
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estu_idEstudiante,estu_nombre,estu_apellido,estu_cod,estu_curso,estu_profid,estu_sede,estu_region,per_idPersona")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            db.Estudiante.Remove(estudiante);
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
