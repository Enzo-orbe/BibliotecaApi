using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Models;

namespace BibliotecaApi.Repositories
{
    public interface IUsersRepository
    {

        Task<Users> Get(int id);
        Task<IEnumerable<Users>> GetAll();
        Task Add(Users users);
        Task Delete(int id);

        Task Update(Users users);
    }
}