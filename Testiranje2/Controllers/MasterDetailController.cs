using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Testiranje2.Controllers
{
    public class MasterDetailController : Controller
    {
        // GET: MasterDetail
        public ActionResult MasterDetail(string BI)
        {
            ViewData["BI"] = BI;
            Testiranje2.Models.StudentEntities db = new Testiranje2.Models.StudentEntities();
            var model = db.Ispits;
            return PartialView("MasterDetailDetailPartial", model.Where(x => x.BI == BI).ToList());
            
        }
    }
}