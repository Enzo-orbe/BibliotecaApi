namespace BibliotecaApi.Dtos
{
    public class UpdateUsersDto
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public System.DateTime UserDateYear { get; set; }
        public int UserNumberOfDocument { get; set; }
        public string UserRol { get; set; }
        public int UserLibrosRetirados { get; set; }
        public bool UserActive { get; set; }
        public string UserPin { get; set; }

    }
}