using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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


            return View(estudiantes.OrderByDescending(e => e.estu_idEstudiante).Take(50));
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
            string llamaListaCommand = "[colegio].[pa_RetornaLista] @idLista";
            ViewBag.FechaActual = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

            using (var cn = db)
            {
                var tb = new DataTable();
             var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = llamaListaCommand;
            cmd.Parameters.Add(new SqlParameter("@idLista", 1));
                cmd.Connection.Open();
            tb.Load(cmd.ExecuteReader());

                ViewBag.ListaSedes = tb;
                ViewBag.listSedes = new SelectList(tb.AsDataView(), "Id", "Name");
                tb = null;
                tb = new DataTable();
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@idLista", 2));
                tb.Load(cmd.ExecuteReader());
                ViewBag.ListaRegiones = tb;
                ViewBag.listRegion = new SelectList(tb.AsDataView(), "Id", "Name");


            }
            return PartialView();
        }



        // POST: Estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante estudiante)
        {
            try { 
            if (ModelState.IsValid)
            {
                    var nombre = new SqlParameter("@nombre", estudiante.estu_nombre);
                    var apellido = new SqlParameter("@apellido", estudiante.estu_apellido);
                    var curso = new SqlParameter("@curso", estudiante.estu_curso);
                    var sede = new SqlParameter("@sede", estudiante.estu_sede);
                    var region = new SqlParameter("@region", estudiante.estu_region);
                    db.Database.ExecuteSqlCommand("[colegio].[pa_agregaEstudiante] @nombre,@apellido," +
                                         "@curso,@sede,@region",nombre,apellido,curso,sede,region);
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(new JsonResult { Data = "Se agrego correctamente"});
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new JsonResult { Data = Newtonsoft.Json.JsonConvert.SerializeObject("Error algunos de los campos no son validos") });
            }
            catch(Exception except)
            {
                return Json(new JsonResult { Data = Newtonsoft.Json.JsonConvert.SerializeObject(except.Message) });
            }
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
