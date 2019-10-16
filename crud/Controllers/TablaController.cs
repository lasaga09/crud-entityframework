using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crud.Models;


namespace crud.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<TablaModel> lista;
            using (entityEntities db = new entityEntities())
            {
                 lista = (from t in db.tabla
                             select new TablaModel
                             {
                                 id = t.id,
                                 nombre = t.nombre,
                                 correo = t.correo,
                                 fecha = t.fecha


                             }).ToList();

            }
            return View(lista);
        }



        public ActionResult New()
        {
            return View();
        }


        [HttpPost]
        public ActionResult New(TablaViewModel model)
        {
            try
            {
                //validamos
                if (ModelState.IsValid)
                {
                    using (entityEntities db=new entityEntities())
                    {
                        var t = new tabla();
                        t.nombre = model.nombre;
                        t.correo = model.correo;
                        t.fecha = model.fecha;

                        //save
                        db.tabla.Add(t);
                        db.SaveChanges();


                    }
                   return Redirect("~/Tabla/");

                }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();

            using(entityEntities db = new entityEntities())
            {
                var t = db.tabla.Find(id);
                model.nombre = t.nombre;
                model.correo = t.correo;
                model.fecha = t.fecha;
                model.id = t.id;
            }
            return View(model);

        }



        [HttpPost]
        public ActionResult Edit(TablaViewModel model)
        {
            try
            {
                //validamos
                if (ModelState.IsValid)
                {
                    using (entityEntities db = new entityEntities())
                    {
                        var t = db.tabla.Find(model.id);
                        t.nombre = model.nombre;
                        t.correo = model.correo;
                        t.fecha = model.fecha;

                        //update
                        db.Entry(t).State=System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }
                   return Redirect("~/Tabla/");

                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (entityEntities db = new entityEntities())
            {
                var t = db.tabla.Find(id);
               

                //update
                db.tabla.Remove(t);
                db.SaveChanges();


            }
            return Redirect("~/Tabla/");
            
        }


    }

    
}