namespace TecnoUniShopApi.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int IdDireccion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public byte[] Contrasena { get; set; } // VARBINARY
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
    }
}