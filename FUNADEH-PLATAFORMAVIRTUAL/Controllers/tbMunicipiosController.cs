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
    public class tbMunicipiosController : Controller
    {
        private DB_A6458A_FunadehGenesisEntities db = new DB_A6458A_FunadehGenesisEntities();

        // GET: /tbMunicipios/
        public ActionResult Index()
        {
            var tbmunicipios = db.tbMunicipios.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbDepartamentos);
            return View(tbmunicipios.ToList());
        }

        // GET: /tbMunicipios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // GET: /tbMunicipios/Create
        public ActionResult Create()
        {
            ViewBag.mun_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.mun_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion");
            return View();
        }

        // POST: /tbMunicipios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="mun_Id,mun_Descripcion,dep_Id,mun_UsuarioCrea,mun_FechaCrea,mun_UsuarioModifica,mun_FechaModifica")] tbMunicipios tbMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.tbMunicipios.Add(tbMunicipios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mun_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMunicipios.mun_UsuarioCrea);
            ViewBag.mun_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMunicipios.mun_UsuarioModifica);
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion", tbMunicipios.dep_Id);
            return View(tbMunicipios);
        }

        // GET: /tbMunicipios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            ViewBag.mun_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMunicipios.mun_UsuarioCrea);
            ViewBag.mun_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMunicipios.mun_UsuarioModifica);
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion", tbMunicipios.dep_Id);
            return View(tbMunicipios);
        }

        // POST: /tbMunicipios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="mun_Id,mun_Descripcion,dep_Id,mun_UsuarioCrea,mun_FechaCrea,mun_UsuarioModifica,mun_FechaModifica")] tbMunicipios tbMunicipios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbMunicipios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mun_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMunicipios.mun_UsuarioCrea);
            ViewBag.mun_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario", tbMunicipios.mun_UsuarioModifica);
            ViewBag.dep_Id = new SelectList(db.tbDepartamentos, "dep_Id", "dep_Descripcion", tbMunicipios.dep_Id);
            return View(tbMunicipios);
        }

        // GET: /tbMunicipios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            if (tbMunicipios == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipios);
        }

        // POST: /tbMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
            db.tbMunicipios.Remove(tbMunicipios);
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
