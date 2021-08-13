using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaApi.Dtos;
using BibliotecaApi.Models;
using BibliotecaApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosRepository _librosRepository;
        public LibrosController(ILibrosRepository librosRepository)
        {
            _librosRepository = librosRepository;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Libros>> GetLibros(int id)
        {
            var libros = await _librosRepository.Get(id);
            if (libros == null)
                return NotFound();

            return Ok(libros);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Libros>>> GetLibros()
        {
            var libros = await _librosRepository.GetAll();

            return Ok(libros);

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateLibros(CreateLibrosDto createLibrosDto)
        {
            Libros libros = new()
            {
                LibroTitulo = createLibrosDto.LibroTitulo,
                LibroAutores = createLibrosDto.LibroAutores,
                LibroDescripcion = createLibrosDto.LibroDescripcion,
                LibroPortada = createLibrosDto.LibroPortada,
                LibroStock = createLibrosDto.LibroStock,
                LiroCodigoIsbn = createLibrosDto.LiroCodigoIsbn,
            };

            await _librosRepository.Add(libros);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteLibro(int id)
        {
            await _librosRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateLibro(int id, UpdateLibrosDto updateLibrosDto)
        {
            Libros libros = new()
            {
                LibroTitulo = updateLibrosDto.LibroTitulo,
                LibroAutores = updateLibrosDto.LibroAutores,
                LibroDescripcion = updateLibrosDto.LibroDescripcion,
                LibroPortada = updateLibrosDto.LibroPortada,
                LibroStock = updateLibrosDto.LibroStock,
                LiroCodigoIsbn = updateLibrosDto.LiroCodigoIsbn,
            };

            await _librosRepository.Update(libros);
            return Ok();
        }

    }
}