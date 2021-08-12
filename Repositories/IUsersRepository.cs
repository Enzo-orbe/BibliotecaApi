using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Models;
using BibliotecaApi.QueryFilters;

namespace BibliotecaApi.Repositories
{
    public interface IUsersRepository
    {

        Task<Users> Get(int id);
        Task<Users> GetNumberDocument(int UserNumberOfDocument);
        Task<IEnumerable<Users>> GetAllFilters(UsersQueryFilters filters);
        Task<IEnumerable<Users>> GetAll();
        Task Add(Users users);
        Task Delete(int id);


        // Task<Users> GetByNumberOfDocument(int UserNumberOfDocument);

        Task Update(Users users);
        Task UpdateUserLibros(Users users);
    }
}