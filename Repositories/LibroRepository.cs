using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Data;
using BibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Repositories
{
    public class LibroRepository : ILibrosRepository
    {

        private readonly IDataContext _context;
        public LibroRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Libros libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Libros.FindAsync(id);
            if (itemToDelete == null)
                throw new System.NullReferenceException();

            _context.Libros.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Libros> Get(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<IEnumerable<Libros>> GetAll()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task Update(Libros libros)
        {
            var itemToUpdate = await _context.Libros.FindAsync(libros.LibroId);
            if (itemToUpdate == null)
                throw new System.NullReferenceException();
            itemToUpdate = libros;
            await _context.SaveChangesAsync();
        }
    }
}