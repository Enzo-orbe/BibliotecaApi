using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Models;

namespace BibliotecaApi.Repositories
{
    public interface ILibrosRepository
    {

        Task<Libros> Get(int id);
        Task<IEnumerable<Libros>> GetAll();
        Task Add(Libros libro);
        Task Delete(int id);

        Task Update(Libros libros);
    }
}