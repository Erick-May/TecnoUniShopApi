using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TecnoUniShopAPP.DTOs; // Usamos nuestros DTOs

namespace TecnoUniShopAPP.Servicios
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();

        private readonly string baseUrl = "https://localhost:7292/api";

        // --- Metodo para Iniciar Sesion ---
        public async Task<LoginResponseDto> LoginAsync(string email, string password)
        {
            // 1. Preparamos los datos para enviar
            var loginRequest = new LoginRequestDto
            {
                Email = email,
                Password = password 
                                   
            };

            // 2. Convertimos esos datos a JSON
            var json = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // 3. Hacemos la llamada POST a la API
                // (baseUrl + "/Login/autenticar")
                var response = await client.PostAsync($"{baseUrl}/Login/autenticar", content);

                // 4. Leemos la respuesta JSON
                var jsonRespuesta = await response.Content.ReadAsStringAsync();

                // 5. Convertimos la respuesta JSON a nuestra clase
                var loginResponse = JsonConvert.DeserializeObject<LoginResponseDto>(jsonRespuesta);

                return loginResponse;
            }
            catch (Exception ex)
            {
                // Si la API esta apagada o hay un error de red
                return new LoginResponseDto
                {
                    Exitoso = false,
                    Mensaje = "Error de conexion: " + ex.Message
                };
            }
        }

        // METODO PARA REGISTRAR
        public async Task<GenericResponseDto> RegistrarAsync(ClienteCreateDto nuevoCliente)
        {
            var json = JsonConvert.SerializeObject(nuevoCliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                // Llamamos al endpoint que creamos en la API
                var response = await client.PostAsync($"{baseUrl}/Clientes/registrar", content);
                var jsonRespuesta = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode) // Codigo 200 OK
                {
                    // Convertimos la respuesta (ej: {"mensaje": "Cliente registrado..."})
                    var respuesta = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRespuesta);
                    respuesta.Exitoso = true;
                    return respuesta;
                }
                else // Error 400 (ej: email duplicado)
                {
                    // Convertimos el error (ej: {"mensaje": "El email ya existe..."})
                    var respuestaError = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRespuesta);
                    respuestaError.Exitoso = false;
                    return respuestaError;
                }
            }
            catch (Exception ex)
            {
                // Si la API esta apagada
                return new GenericResponseDto { Exitoso = false, Mensaje = "Error de conexion: " + ex.Message };
            }
        }
    }
}
