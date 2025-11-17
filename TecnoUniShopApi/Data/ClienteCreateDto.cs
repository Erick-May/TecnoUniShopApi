namespace TecnoUniShopApi.DTOs
{
    // DTO para registrar un nuevo Cliente
    public class ClienteCreateDto
    {
        // Datos para Clientes_ts
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public string Telefono { get; set; }

        // Datos para Direccion_ts
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
    }
}