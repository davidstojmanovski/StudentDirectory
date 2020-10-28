using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testiranje2.Controllers;
using Testiranje2.Models;


namespace UnitTesting
{
    [TestClass]
    public class StudentControlTest
    {
        //Arrange
        StudentController stController = new StudentController();
         



        [TestMethod]
        public void GridViewPartialTest()
        {

            StudentController stController = new StudentController();
            //Act
            ActionResult result = (ActionResult)stController.GridViewPartial();
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
