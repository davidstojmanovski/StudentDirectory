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
    public class IspitController : Controller
    {
        // GET: Ispit
        public ActionResult Index()
        {
            return View();
        }

        Testiranje2.Models.StudentEntities db = new Testiranje2.Models.StudentEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.Ispits;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Testiranje2.Models.Ispit item)
        {
            var model = db.Ispits;
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
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Testiranje2.Models.Ispit item)
        {
            var model = db.Ispits;
            if (ModelState.IsValid)
            {
                try
                {
                    using (StudentEntities se = new StudentEntities())
                    {
                        se.Entry(item).State = EntityState.Modified;
                        se.SaveChanges();
                    }

                 
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
        public ActionResult GridViewPartialDelete(System.String BI,System.String PredmetId)
        {
            var model = db.Ispits;
            BI = BI.TrimStart(' ', '"');
            BI = BI.TrimEnd(' ', '"');

            PredmetId = PredmetId.TrimStart(' ', '"');
            PredmetId=PredmetId.TrimEnd(' ', '"');

            if (BI != null)
            {
                try
                {
                    var item = model.Where(x => x.BI == BI && x.PredmetId == PredmetId).FirstOrDefault();
                    
                    if (item != null)
                        model.Remove(item);
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