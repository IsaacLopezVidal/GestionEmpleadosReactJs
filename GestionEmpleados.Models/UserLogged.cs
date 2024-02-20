namespace GestionEmpleados.Models
{
    public class UserLogged
    {
        public string token { get; set; }
        public DataUser user { get; set; }
    }
    public class DataUser
    {
        public string username { get; set; }
        public int id { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
    }
    public class Roles
    {
        public int Id { get; set; }
        public string Rol { get; set; }
    }
}
