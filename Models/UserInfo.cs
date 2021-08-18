namespace BibliotecaApi.Models
{
    public class UserInfo
    {
        public int UserId {get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public System.DateTime UserDateYear { get; set; }
        public int UserNumberOfDocument { get; set; }
        public string UserRol { get; set; }
        public bool UserActive { get; set; }
        public string UserPin { get; set; }
    }
}