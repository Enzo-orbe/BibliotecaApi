using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
using System.Threading.Tasks;
using System.Threading;

namespace BibliotecaApi.Data
{
    public interface IDataContext
    {

        DbSet<Libros> Libros { get; set; }
        DbSet<Users> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}