using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class Users
    {

        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Debe ingresar un maximo de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar un minimo de 2 caracteres")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100, ErrorMessage = "Debe ingresar un maximo de 100 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar un minimo de 2 caracteres")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha de nacimiento")]
        [DataType(DataType.Date)]
        public DateTime UserDateYear { get; set; }

        [Required(ErrorMessage = "Debe ingresar un numero de documento")]
        public string UserNumberOfDocument { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Rol de usuario")]
        // [EnumDataType(["Socio", "Admin"])]
        public string UserRol { get; set; }

        [Required(ErrorMessage = "Debe indicar cuantos libros retira")]
        public int UserLibrosRetirados { get; set; }

        public Boolean UserActive { get; set; }

        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        public string UserPin { get; set; }
    }
}