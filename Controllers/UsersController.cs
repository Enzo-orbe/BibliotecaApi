using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BibliotecaApi.Dtos;
using BibliotecaApi.Models;
using BibliotecaApi.QueryFilters;
using BibliotecaApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _userRepository = usersRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _userRepository.GetAll();

            return Ok(users);

        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUsersDto createUsersDto)
        {
            Users users = new()
            {
                UserName = createUsersDto.UserName,
                UserLastName = createUsersDto.UserLastName,
                UserDateYear = createUsersDto.UserDateYear,
                UserLibrosRetirados = createUsersDto.UserLibrosRetirados,
                UserActive = createUsersDto.UserActive,
                UserNumberOfDocument = createUsersDto.UserNumberOfDocument,
                UserPin = createUsersDto.UserPin,
                UserRol = createUsersDto.UserRol,
            };

            await _userRepository.Add(users);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("/user/{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUsersDto updateUsersDto)
        {
            Users users = new()
            {
                UserName = updateUsersDto.UserName,
                UserLastName = updateUsersDto.UserLastName,
                UserDateYear = updateUsersDto.UserDateYear,
                UserLibrosRetirados = updateUsersDto.UserLibrosRetirados,
                UserActive = updateUsersDto.UserActive,
                UserNumberOfDocument = updateUsersDto.UserNumberOfDocument,
                UserPin = updateUsersDto.UserPin,
                UserRol = updateUsersDto.UserRol,
            };

            await _userRepository.Update(users);
            return Ok();
        }

        [HttpPut]
        [Route("/accept/{id}")]
        public async Task<ActionResult> UpdateUserActive(int id, UpdateUserActiveDto updateUserActiveDto)
        {
            var data = await _userRepository.Get(id);
            Users users = new()
            {
                UserId = data.UserId,
                UserName = data.UserName,
                UserDateYear = data.UserDateYear,
                UserLastName = data.UserLastName,
                UserLibrosRetirados = data.UserLibrosRetirados,
                UserPin = data.UserPin,
                UserRol = data.UserRol,
                UserNumberOfDocument = data.UserNumberOfDocument,
                UserActive = updateUserActiveDto.UserActive,
            };

            await _userRepository.Update(users);
            return Ok();
        }

        [HttpPut]
        [Route("/retiro/{id}")]
        public async Task<ActionResult> UpdateUserLibros(int id, UserLibrosRetiradosDto userLibrosRetiradosDto)
        {
            var data = await _userRepository.Get(id);
            if (data.UserLibrosRetirados + userLibrosRetiradosDto.UserLibrosRetirados <= 3 || 17 > 18)
            {
                Users users = new()
                {
                    UserId = data.UserId,
                    UserName = data.UserName,
                    UserDateYear = data.UserDateYear,
                    UserLastName = data.UserLastName,
                    UserLibrosRetirados = data.UserLibrosRetirados + userLibrosRetiradosDto.UserLibrosRetirados,
                    UserPin = data.UserPin,
                    UserRol = data.UserRol,
                    UserNumberOfDocument = data.UserNumberOfDocument,
                    UserActive = data.UserActive,
                };

                await _userRepository.Update(users);
                return Ok(users);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/filtered")]
        public async Task<ActionResult<Users>> GetUserLogin([FromQuery] UsersQueryFilters filters)
        {
            var user = await _userRepository.GetAllFilters(filters);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}