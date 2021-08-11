namespace BibliotecaApi.Dtos
{
    public class UpdateLibrosDto
    {

        public string LibroTitulo { get; set; }
        public string LibroAutores { get; set; }
        public int LibroStock { get; set; }
        public string LibroPortada { get; set; }
        public string LibroDescripcion { get; set; }
        public string LiroCodigoIsbn { get; set; }
    }
}