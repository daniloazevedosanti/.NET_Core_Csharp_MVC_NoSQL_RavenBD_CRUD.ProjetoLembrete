using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoLembrete.Models;

namespace ProjetoLembrete.Controllers
{
    public class LembretesController : Controller
    {
        private ContextoDB db = new ContextoDB();

        // GET: Lembretes
        public ActionResult Index()
        {
            return View(db.lembretes.ToList());
        }

        // GET: Lembretes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembrete lembrete = db.lembretes.Find(id);
            if (lembrete == null)
            {
                return HttpNotFound();
            }
            return View(lembrete);
        }

        // GET: Lembretes/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
     
        //Metodo custumizado
        public ActionResult Create([Bind(Include = "Id,Titulo,Descricao,Data")] Lembrete lembrete)
          {
             if (ModelState.IsValid)
             {
              db.lembretes.Add(lembrete);
              db.SaveChanges();

            // return RedirectToAction("Create", lembrete);

            ViewBag.Msg = lembrete.ToString();
            ModelState.Clear();
            return View("Create");
           }
         ModelState.Clear();
         return View();
        }

        // GET: Lembretes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembrete lembrete = db.lembretes.Find(id);
            if (lembrete == null)
            {
                return HttpNotFound();
            }
            return View(lembrete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descricao,Data")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lembrete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lembrete);
        }

        // GET: Lembretes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lembrete lembrete = db.lembretes.Find(id);
            if (lembrete == null)
            {
                return HttpNotFound();
            }
            return View(lembrete);
        }

        // POST: Lembretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lembrete lembrete = db.lembretes.Find(id);
            db.lembretes.Remove(lembrete);
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
