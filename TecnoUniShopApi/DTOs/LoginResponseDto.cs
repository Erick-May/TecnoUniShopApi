namespace TecnoUniShopApi.DTOs
{
    public class LoginResponseDto
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public string Token { get; set; } // El pase V.I.P.
        public string Rol { get; set; }
    }
}
