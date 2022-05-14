using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using CalidadT2.Repositories;
using CalidadT2.Controllers;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using CalidadT2.Services;
namespace Pruebas.Controllers
{
    class HomeControllerTest
    {
        [Test]
        public void TestLogin01()
        {

            var mock = new Mock<ILibroRepository>();
            mock.Setup(o => o.GetAllLibros()).Returns(new List<Libro>());
            var controller = new HomeController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
