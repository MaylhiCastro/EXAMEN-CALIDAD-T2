using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IBibliotecaRepository
    {
        List<Biblioteca> GetBibliotecaByUser(int UsuarioId);
        void AddBiblioteca(Biblioteca biblioteca);

        void MarcarLeido(Biblioteca biblioteca);
        void MarcarTerminado(Biblioteca biblioteca);

        Biblioteca FindBibliotecaByLibro(int UsuarioId, int libroId);


    }
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly AppBibliotecaContext context;

        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }

        public void AddBiblioteca(Biblioteca biblioteca)
        {
            context.Bibliotecas.Add(biblioteca);
            context.SaveChanges();
        }

        public Biblioteca FindBibliotecaByLibro(int UsuarioId, int libroId)
        {
            return context.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == UsuarioId)
                .FirstOrDefault();
        }

        public List<Biblioteca> GetBibliotecaByUser(int UsuarioId)
        {
            return context.Bibliotecas
                 .Include(o => o.Libro.Autor)
                 .Include(o => o.Usuario)
                 .Where(o => o.UsuarioId == UsuarioId)
                 .ToList();
        }

        public void MarcarLeido(Biblioteca biblioteca)
        {
            biblioteca.Estado = ESTADO.LEYENDO;
            context.SaveChanges();
        }

        public void MarcarTerminado(Biblioteca biblioteca)
        {
            biblioteca.Estado = ESTADO.TERMINADO;
            context.SaveChanges();
        }
    }
}
