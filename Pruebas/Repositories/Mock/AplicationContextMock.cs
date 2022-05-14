using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pruebas.Repositories.Mock
{
    class AplicationContextMock
    {
        public static Mock<AppBibliotecaContext> GetApplicationContextMock()
        {
            

            IQueryable<Libro> libroData = GetLibroData();

            var mockDbSetLibro = new Mock<DbSet<Libro>>();
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Provider).Returns(libroData.Provider);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Expression).Returns(libroData.Expression);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.ElementType).Returns(libroData.ElementType);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.GetEnumerator()).Returns(libroData.GetEnumerator());
            mockDbSetLibro.Setup(m => m.AsQueryable()).Returns(libroData);



            var mockContext = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            mockContext.Setup(c => c.Libros).Returns(mockDbSetLibro.Object);

            return mockContext;
        }

        

        private static IQueryable<Libro> GetLibroData()
        {
            return new List<Libro>
            {
                new Libro {
                    Id = 1,
                    Nombre = "pinocho"
                },
                new Libro {
                    Id = 1,
                    Nombre = "harry potter"
                },
            }.AsQueryable();
        }
    }
}
