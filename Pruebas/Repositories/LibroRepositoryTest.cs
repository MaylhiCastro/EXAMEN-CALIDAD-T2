using CalidadT2.Models;
using CalidadT2.Repositories;
using Moq;
using NUnit.Framework;
using Pruebas.Repositories.Mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas.Repositories
{
    class LibroRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockContext;

        
        [SetUp]
        public void SetUp()
        {
            mockContext = AplicationContextMock.GetApplicationContextMock();
        }

        [Test]
        public void TestGetAllLibros()
        {
            var repository = new LibroRepository(mockContext.Object);
            var libros = repository.GetAllLibros();

            Assert.IsNotNull(libros);
        }
        [Test]
        public void TestDetailLibro()
        {
            var repository = new LibroRepository(mockContext.Object);
            var libro = repository.DetailLibro(1);

            Assert.IsNotNull(libro);
            Assert.AreEqual(libro.Nombre,"pinocho");
        }
        [Test]
        public void TestGetLibroById()
        {
            var repository = new LibroRepository(mockContext.Object);
            var libro = repository.GetLibroById(1);

            Assert.IsNotNull(libro);
            Assert.AreEqual(libro.Nombre, "pinocho");
        }

    }
}
