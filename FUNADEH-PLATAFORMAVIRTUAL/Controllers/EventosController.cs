using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FUNADEH_PLATAFORMAVIRTUAL.Models;

namespace FUNADEH_PLATAFORMAVIRTUAL.Controllers
{
    public class EventosController : Controller
    {
        private GeneracionIngresosEntities db = new GeneracionIngresosEntities();

        // GET: /Eventos/

        public ActionResult List()
        {
            var tbeventos = db.tbEventos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbeventos.ToList());
        }
        public ActionResult Index()
        {
            var tbeventos = db.tbEventos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbeventos.ToList());
        }

        // GET: /Eventos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEventos tbEventos = db.tbEventos.Find(id);
            if (tbEventos == null)
            {
                return HttpNotFound();
            }
            return View(tbEventos);
        }

        // GET: /Eventos/Create
        public ActionResult Create()
        {
            ViewBag.even_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.even_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            return View();
        }

        // POST: /Eventos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="even_Id,even_Descripcion,even_Estado,even_UsuarioCrea,even_FechaCrea,even_UsuarioModifica,even_FechaModifica")] tbEventos tbEventos)
        {
            if (ModelState.IsValid)
            {
                db.tbEventos.Add(tbEventos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.even_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEventos.even_UsuarioCrea);
            ViewBag.even_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEventos.even_UsuarioModifica);
            return View(tbEventos);
        }

        // GET: /Eventos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEventos tbEventos = db.tbEventos.Find(id);
            if (tbEventos == null)
            {
                return HttpNotFound();
            }
            ViewBag.even_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEventos.even_UsuarioCrea);
            ViewBag.even_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEventos.even_UsuarioModifica);
            return View(tbEventos);
        }

        // POST: /Eventos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="even_Id,even_Descripcion,even_Estado,even_UsuarioCrea,even_FechaCrea,even_UsuarioModifica,even_FechaModifica")] tbEventos tbEventos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEventos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.even_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEventos.even_UsuarioCrea);
            ViewBag.even_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbEventos.even_UsuarioModifica);
            return View(tbEventos);
        }

        // GET: /Eventos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEventos tbEventos = db.tbEventos.Find(id);
            if (tbEventos == null)
            {
                return HttpNotFound();
            }
            return View(tbEventos);
        }

        // POST: /Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEventos tbEventos = db.tbEventos.Find(id);
            db.tbEventos.Remove(tbEventos);
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
