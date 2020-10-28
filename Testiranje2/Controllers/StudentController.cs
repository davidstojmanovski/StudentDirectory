using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testiranje2.Models;

namespace Testiranje2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        Testiranje2.Models.StudentEntities db = new Testiranje2.Models.StudentEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.Students;
            return PartialView("_GridViewPartial", model.ToList());
        }


        public ActionResult MasterDetail(string BI)
        {
            ViewData["BI"] = BI;
            Testiranje2.Models.StudentEntities db = new Testiranje2.Models.StudentEntities();
            var model = db.Ispits;
            return PartialView("MasterDetailDetailPartial", model.Where(x => x.BI == BI).ToList());

        }






        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Testiranje2.Models.Student item)
        {
            var model = db.Students;

            item.Ime = "David";
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Testiranje2.Models.Student item)
        {
            var model = db.Students;
            if (ModelState.IsValid)
            {
                try
                {
                    string BI = item.BI;

                    using (StudentEntities se=new StudentEntities())
                    {
                        se.Entry(item).State = EntityState.Modified;
                        se.SaveChanges();
                    }

                   // var modelItem = model.FirstOrDefault(it => it.BI == item.BI);
                   // if (modelItem != null)
                   // {
                     //   System.Diagnostics.Debug.WriteLine(item.Ime + item.Prezime+ item.BI);
                      //   this.UpdateModel(item);
                       // db.Entry((Models.Student)item).State = EntityState.Modified;
                        //db.Entry(item).State = System.Data.Entity.EntityState.Modified; bilo zakomentarisano
                        //this.UpdateModel(item); bilo zakomentarisano
                       // db.SaveChanges();
                   // }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.String BI)
        {
            
            var model = db.Students;
            var model2 = db.Ispits;
            //skidaju se navodnici jer ih devexpress stavlja iz nekog razloga
            BI = BI.TrimStart(' ','"');
            BI = BI.TrimEnd(' ', '"');
            if (BI != null)
            {
                try
                {
                    //var item = model.FirstOrDefault(it => it.BI == BI);
                    var item = model.Where(x => x.BI == BI).FirstOrDefault();
                    if (item != null)
                    {
                        model.Remove(item);
                        List<Ispit> listOfIspits = model2.Where(x => x.BI == BI).ToList();
                        //brisemo sve ispite tog studenta
                        foreach(Ispit ispit in listOfIspits)
                        {
                            model2.Remove(ispit);

                        }

                    }

                    db.SaveChanges();
                    
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}