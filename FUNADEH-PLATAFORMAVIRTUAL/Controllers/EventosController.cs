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
        private DB_A6458A_FunadehGenesisEntities db = new DB_A6458A_FunadehGenesisEntities();


        public ActionResult Index()
        {
            tbEventos tbeventos = new tbEventos();
            return View(tbeventos);

        }
    

    [HttpPost]
    public JsonResult llenarTabla()
    {
        try
        {
            db = new DB_A6458A_FunadehGenesisEntities();

            var tbEventos = db.tbEventos
                .Select(
                t => new
                {
                    even_Id = t.even_Id,
                    even_Descripcion = t.even_Descripcion,
                    even_Estado = t.even_Estado,

                }
                ).ToList();

            return Json(tbEventos, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
            ex.ToString();
            throw;
        }
    }

    // GET: /Eventos/Create
    public ActionResult Create()
        {
            ViewBag.even_UsuarioCrea = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            ViewBag.even_UsuarioModifica = new SelectList(db.tbUsuarios, "usu_Id", "usu_NombreUsuario");
            return View();
        }

        [HttpPost]
        public JsonResult Create(tbEventos tbeventos)
        {
            string msj = "";
            if (tbeventos.even_Descripcion != "")
            {
                //var usuario = (tbUsuarios)Session["Usuario"];
                try
                {
                    db = new DB_A6458A_FunadehGenesisEntities();
                    var list = db.UDP_Lin_tb_Eventos_Insert(tbeventos.even_Descripcion, 1, DateTime.Now);
                    foreach (UDP_Lin_tb_Eventos_Insert_Result item in list)
                    {
                        msj = item.MensajeError + " ";
                    }
                }
                catch (Exception ex)
                {
                    msj = "-2";
                    ex.Message.ToString();
                }
            }
            else
            {
                msj = "-3";
            }
            return Json(msj.Substring(0, 2), JsonRequestBehavior.AllowGet);
            }
        

        // GET: /Eventos/Edit/5
        [HttpGet]
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEventos tbEventos = null;
            try
            {
                db = new DB_A6458A_FunadehGenesisEntities();
                tbEventos = db.tbEventos.Find(id);
                if(tbEventos ==null)
                {
                    return HttpNotFound();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return HttpNotFound();
            }
            var eventos = new tbEventos
            {
                even_Id = tbEventos.even_Id,
                even_Descripcion = tbEventos.even_Descripcion,
                even_Estado = tbEventos.even_Estado,
                even_UsuarioCrea = tbEventos.even_UsuarioCrea,
                even_FechaCrea = tbEventos.even_FechaCrea,
                even_UsuarioModifica = tbEventos.even_UsuarioModifica,
                even_FechaModifica = tbEventos.even_FechaModifica,
                tbUsuarios = new tbUsuarios { usu_NombreUsuario = IsNull(tbEventos.tbUsuarios).usu_NombreUsuario },
                tbUsuarios1 = new tbUsuarios { usu_NombreUsuario = IsNull(tbEventos.tbUsuarios1).usu_NombreUsuario }

            };
            return Json(eventos, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Edit(tbEventos tbEventos)
        {
            string msj = "";
            if(tbEventos.even_Id !=0 && tbEventos.even_Descripcion !="")
            {
                //var id = (int)Session["id"];
                //var usuario =(tbUsuarios)Session["Usuario"]
                try
                {
                    db = new DB_A6458A_FunadehGenesisEntities();
                    var list = db.UDP_Lin_tbEventos_Update(tbEventos.even_Id, tbEventos.even_Descripcion, 1, DateTime.Now);
                    foreach(UDP_Lin_tbEventos_Update_Result item in list)
                    {
                        msj = item.MensajeError + "  ";
                    }
                }
                catch (Exception ex)
                {
                    msj = "-2";
                    ex.Message.ToString();
                }
            }
            else
            {
                msj = "-3";
            }
            return Json(msj.Substring(0, 2), JsonRequestBehavior.AllowGet);
                
        }

        // GET: /Eventos/Delete/5
        public ActionResult Delete(tbEventos tbEventos)
        {
            string msj = "";
            //string RazonInactivo = "Se ha Inhabilitado este Registro";

            if(tbEventos.even_Id != 0)
            {
                var id = (int)Session["id"];
                var usuario = (tbUsuarios)Session["Usuario"];
                try
                {
                    db = new DB_A6458A_FunadehGenesisEntities();
                    var list = db.UDP_Lin_tbEventos_Delete(tbEventos.even_Id, false, 1, DateTime.Now);
                    foreach (UDP_Lin_tbEventos_Delete_Result item in list)
                    {
                        msj = item.MensajeError + " ";
                    }

                }
                catch (Exception ex)
                {

                    msj = "-2";
                    ex.Message.ToString();
                }
                //Session.Remove("id");
            }
            else
            {
                msj = "-3";
            }
            return Json(msj.Substring(0, 2), JsonRequestBehavior.AllowGet);
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

        protected tbUsuarios IsNull(tbUsuarios valor)
        {
            if (valor != null)
            {
                return valor;
            }
            else
            {
                return new tbUsuarios { usu_NombreUsuario = "" };
            }
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
