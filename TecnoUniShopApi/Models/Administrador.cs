namespace TecnoUniShopApi.Models
{
    public class Administrador
    {
        public int IdAdmin { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public byte[] Contrasena { get; set; } // VARBINARY
        public string Rol { get; set; }
    }
}