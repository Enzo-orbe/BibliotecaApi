using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Data;
using BibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Repositories
{
    public class UserRepository : IUsersRepository
    {

        private readonly IDataContext _context;
        public UserRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task Add(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Users.FindAsync(id);
            if (itemToDelete == null)
                throw new System.NullReferenceException();

            _context.Users.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Update(Users users)
        {
            var itemToUpdate = await _context.Users.FindAsync(users.UserId);
            System.Console.Write(itemToUpdate);
            if (itemToUpdate == null)
            {
                throw new System.NullReferenceException();
            }
            else
            {
                itemToUpdate.UserName = users.UserName;
                itemToUpdate.UserLastName = users.UserLastName;
                itemToUpdate.UserDateYear = users.UserDateYear;
                itemToUpdate.UserLibrosRetirados = users.UserLibrosRetirados;
                itemToUpdate.UserPin = users.UserPin;
                itemToUpdate.UserRol = users.UserRol;
                itemToUpdate.UserNumberOfDocument = users.UserNumberOfDocument;
                itemToUpdate.UserActive = users.UserActive;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Users> GetByNumberOfDocument(int UserNumberOfDocument)
        {
            var user = await _context.Users.FindAsync(UserNumberOfDocument);
            return user;
        }
    }
}