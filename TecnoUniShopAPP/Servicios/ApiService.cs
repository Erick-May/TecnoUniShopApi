using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers; // ¡Nuevo using para el Token!
using System.Text;
using System.Threading.Tasks;
using TecnoUniShopAPP.DTOs;

namespace TecnoUniShopAPP.Servicios
{
    public class ApiService
    {
        private static readonly HttpClient client = new HttpClient();
        // Asegúrate que este puerto sea el correcto de tu API (el que sale en Swagger)
        private readonly string baseUrl = "https://localhost:7292/api";

        // --- Login y Registro (Ya los tenías) ---
        public async Task<LoginResponseDto> LoginAsync(string email, string password)
        {
            var loginRequest = new LoginRequestDto { Email = email, Password = password };
            var json = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/Login/autenticar", content);
                var jsonRespuesta = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LoginResponseDto>(jsonRespuesta);
            }
            catch (Exception ex)
            {
                return new LoginResponseDto { Exitoso = false, Mensaje = "Error de conexion: " + ex.Message };
            }
        }

        public async Task<GenericResponseDto> RegistrarAsync(ClienteCreateDto nuevoCliente)
        {
            var json = JsonConvert.SerializeObject(nuevoCliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/Clientes/registrar", content);
                var jsonRespuesta = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var res = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRespuesta);
                    res.Exitoso = true;
                    return res;
                }
                else
                {
                    var res = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRespuesta);
                    res.Exitoso = false;
                    return res;
                }
            }
            catch (Exception ex)
            {
                return new GenericResponseDto { Exitoso = false, Mensaje = "Error: " + ex.Message };
            }
        }

        // --- ¡¡MÉTODOS NUEVOS PARA EL MENU!! ---

        // 1. Obtener todos los productos
        public async Task<List<ProductoReadDto>> GetProductosAsync(string token)
        {
            // Ponemos el token en la cabecera (Authorization: Bearer ...)
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await client.GetAsync($"{baseUrl}/Productos");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ProductoReadDto>>(json);
                }
                return null; // O una lista vacía
            }
            catch
            {
                return null;
            }
        }

        // 1. Obtener Categorias (Para el ComboBox)
        public async Task<List<CategoriaReadDto>> GetCategoriasAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.GetAsync($"{baseUrl}/Categorias");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CategoriaReadDto>>(json);
                }
                return new List<CategoriaReadDto>();
            }
            catch { return new List<CategoriaReadDto>(); }
        }

        // 2. Crear Producto
        public async Task<GenericResponseDto> CrearProductoAsync(string token, ProductoCreateDto producto)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/Productos", content);
                var jsonRes = await response.Content.ReadAsStringAsync();
                var resDto = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRes); // Reusamos GenericResponseDto
                resDto.Exitoso = response.IsSuccessStatusCode;
                return resDto;
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

        // 3. Actualizar Producto
        public async Task<GenericResponseDto> ActualizarProductoAsync(string token, int id, ProductoUpdateDto producto)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PutAsync($"{baseUrl}/Productos/{id}", content);
                var jsonRes = await response.Content.ReadAsStringAsync();
                var resDto = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRes);
                resDto.Exitoso = response.IsSuccessStatusCode;
                return resDto;
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

        // 4. Eliminar (Desactivar) Producto
        public async Task<GenericResponseDto> EliminarProductoAsync(string token, int id)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.DeleteAsync($"{baseUrl}/Productos/{id}");
                var jsonRes = await response.Content.ReadAsStringAsync();
                var resDto = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRes);
                resDto.Exitoso = response.IsSuccessStatusCode;
                return resDto;
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

    }
}