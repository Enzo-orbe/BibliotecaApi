using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class Libros
    {
        [Key]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El nombre del libro es requerido")]
        [MaxLength(100, ErrorMessage = "Debe ingresar un maximo de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar un minimo de 2 caracteres")]
        public string LibroTitulo { get; set; }

        [Required(ErrorMessage = "Debe ingresar un autor")]
        public string LibroAutores { get; set; }

        [Required(ErrorMessage = "Debe indicar un stock")]
        public int LibroStock { get; set; }

        public string LibroPortada { get; set; }

        [Required(ErrorMessage = "Debe indicar una descripcion")]
        [MaxLength(100, ErrorMessage = "Debe ingresar un maximo de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar un minimo de 2 caracteres")]
        public string LibroDescripcion { get; set; }

        [Required(ErrorMessage = "Debe indicar un codigo ISBN")]
        public string LiroCodigoIsbn { get; set; }
    }
}
