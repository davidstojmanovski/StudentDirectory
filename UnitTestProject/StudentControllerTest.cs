using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Testiranje2.Controllers;
using Testiranje2.Models;
using System.Web.Mvc;
using System.Globalization;

namespace UnitTestProject
{
    [TestClass]
    public class StudentControllerTest
    {

       

        StudentController cont = new StudentController();
        Student student1;
        Student student2;
        Student student3;
        Student student4;

        [TestInitialize]
            public void TestInitialize()
        {
            student1 = new Student();
            student2 = new Student();
            student3 = new Student();
            student4 = new Student();

            student1.BI = "31-14";
            student1.Ime = "Zoran";
            student1.Prezime = "Jovanovic";
            student1.Adresa = "Gospodara Jovanova 2";
            student1.Grad = "Uzice";

            student2.BI = "42-15";
            student1.Ime = "Marko";
            student1.Prezime = "Zoric";
            student1.Adresa = "Majke Jevrosime 5";
            student1.Grad = "Pozarevac";

            student1.BI = "108-18";
            student1.Ime = "Damir";
            student1.Prezime = "Pavlovic";
            student1.Adresa = "Goce Delceva 13";
            student1.Grad = "Sombor";

            student1.BI = "76-16";
            student1.Ime = "Mirko";
            student1.Prezime = "Peric";
            student1.Adresa = "Lenjinova 12";
            student1.Grad = "Kragujevac";

        }


        [TestMethod]

        public void MasterDetailTest()
        {

            PartialViewResult result1 = (PartialViewResult)cont.MasterDetail(student1.BI);
            PartialViewResult result2 = (PartialViewResult)cont.MasterDetail(student2.BI);
            PartialViewResult result3 = (PartialViewResult)cont.MasterDetail(student3.BI);
            PartialViewResult result4 = (PartialViewResult)cont.MasterDetail(student4.BI);

            Assert.AreEqual(result1.ViewName, "MasterDetailDetailPartial");
            Assert.IsNotNull(result1.Model);

            Assert.AreEqual(result1.ViewName, "MasterDetailDetailPartial");
            Assert.IsNotNull(result2.Model);

            Assert.AreEqual(result1.ViewName, "MasterDetailDetailPartial");
            Assert.IsNotNull(result3.Model);

            Assert.AreEqual(result1.ViewName, "MasterDetailDetailPartial");
            Assert.IsNotNull(result4.Model);

        }


        [TestMethod]
        public void GridViewPartialTest()
        {
            
            PartialViewResult result = (PartialViewResult)cont.GridViewPartial();

            Assert.AreEqual(result.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result.Model);

        }

        [TestMethod]
        public void AddNewTest()
        {
            
            PartialViewResult result1 = (PartialViewResult)cont.GridViewPartialAddNew(student1);
            PartialViewResult result2 = (PartialViewResult)cont.GridViewPartialAddNew(student2);
            PartialViewResult result3 = (PartialViewResult)cont.GridViewPartialAddNew(student3);
            PartialViewResult result4 = (PartialViewResult)cont.GridViewPartialAddNew(student4);


            Assert.AreEqual(result1.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result1.Model);

            Assert.AreEqual(result2.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result2.Model);

            Assert.AreEqual(result3.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result3.Model);

            Assert.AreEqual(result4.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result4.Model);
        }


        [TestMethod]
        public void UpdateTest()
        {
            student1.Grad="Paracin";
            student2.Grad="Cacak";
            student3.Grad="Novi Sad";
            student4.Grad="Subotica";

            PartialViewResult result1 = (PartialViewResult)cont.GridViewPartialUpdate(student1);
            PartialViewResult result2 = (PartialViewResult)cont.GridViewPartialUpdate(student2);
            PartialViewResult result3 = (PartialViewResult)cont.GridViewPartialUpdate(student3);
            PartialViewResult result4 = (PartialViewResult)cont.GridViewPartialUpdate(student4);
           
            Assert.AreEqual(result1.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result1.Model);

            Assert.AreEqual(result2.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result2.Model);

            Assert.AreEqual(result3.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result3.Model);

            Assert.AreEqual(result4.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result4.Model);

        }


        [TestMethod]
        public void deleteTest()
        {

            

            PartialViewResult result1 = (PartialViewResult)cont.GridViewPartialDelete(student1.BI);
            PartialViewResult result2 = (PartialViewResult)cont.GridViewPartialDelete(student2.BI);
            PartialViewResult result3 = (PartialViewResult)cont.GridViewPartialDelete(student3.BI);
            PartialViewResult result4 = (PartialViewResult)cont.GridViewPartialDelete(student4.BI);

            Assert.AreEqual(result1.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result1.Model);

            Assert.AreEqual(result2.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result2.Model);

            Assert.AreEqual(result3.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result3.Model);

            Assert.AreEqual(result4.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result4.Model);
        }


    }
}
