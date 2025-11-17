namespace TecnoUniShopApi.Models
{
    public class Repartidor
    {
        public int IdRepartidor { get; set; }
        public string NombreRepartidor { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Vehiculo { get; set; }
        public string Email { get; set; }
        public byte[] Contrasenia { get; set; }
    }
}