using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testiranje2.Controllers;
using Testiranje2.Models;
using System.Web.Mvc;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class IspitControllerTest
    {





        IspitController cont2 = new IspitController();
        Ispit ispit1;
        Ispit ispit2;
        Ispit ispit3;
        Ispit ispit4;

        [TestInitialize]
        public void TestInitialize()
        {
            ispit1 = new Ispit();
            ispit1.BI = "31-14";
            ispit1.PredmetId = "n306";
            ispit1.Ocena = 8;

            ispit2 = new Ispit();
            ispit2.BI = "42-15";
            ispit2.PredmetId = "n105";
            ispit2.Ocena = 7;

            ispit3 = new Ispit();
            ispit3.BI = "108-18";
            ispit3.PredmetId = "n207";
            ispit3.Ocena = 6;

            ispit4 = new Ispit();
            ispit4.BI = "76-16";
            ispit4.PredmetId = "i102";
            ispit4.Ocena = 9;

            

        }
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        




        [TestMethod]
        public void GridViewPartialIspitTest()
        {

            PartialViewResult result = (PartialViewResult)cont2.GridViewPartial();



            Assert.AreEqual(result.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void AddNewIspitTest()
        {
            

            PartialViewResult result1=(PartialViewResult)cont2.GridViewPartialAddNew(ispit1);
            PartialViewResult result2 = (PartialViewResult)cont2.GridViewPartialAddNew(ispit2);
            PartialViewResult result3 = (PartialViewResult)cont2.GridViewPartialAddNew(ispit3);
            PartialViewResult result4 = (PartialViewResult)cont2.GridViewPartialAddNew(ispit4);
           //1
            Assert.AreEqual(result1.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result1.Model);
            //2
            Assert.AreEqual(result2.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result2.Model);
            //3
            Assert.AreEqual(result3.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result3.Model);
            //4
            Assert.AreEqual(result4.ViewName, "_GridViewPartial");
            Assert.IsNotNull(result4.Model);
        }

        [TestMethod]
        public void UpdateIspitTest()
        {
            ispit1.Ocena = 9;
            ispit2.Ocena = 7;
            ispit3.Ocena = 6;
            ispit4.Ocena = 8;

            PartialViewResult result1 = (PartialViewResult)cont2.GridViewPartialUpdate(ispit1);
            PartialViewResult result2 = (PartialViewResult)cont2.GridViewPartialUpdate(ispit2);
            PartialViewResult result3 = (PartialViewResult)cont2.GridViewPartialUpdate(ispit3);
            PartialViewResult result4 = (PartialViewResult)cont2.GridViewPartialUpdate(ispit4);

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
        public void DeleteIspitTest()
        {
            PartialViewResult result1 = (PartialViewResult)cont2.GridViewPartialDelete(ispit1.BI, ispit1.PredmetId);
            PartialViewResult result2 = (PartialViewResult)cont2.GridViewPartialDelete(ispit2.BI, ispit2.PredmetId);
            PartialViewResult result3 = (PartialViewResult)cont2.GridViewPartialDelete(ispit3.BI, ispit3.PredmetId);
            PartialViewResult result4 = (PartialViewResult)cont2.GridViewPartialDelete(ispit4.BI, ispit4.PredmetId);

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
