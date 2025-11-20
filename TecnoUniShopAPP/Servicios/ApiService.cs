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

        // --- NUEVO METODO PARA EL CARRITO ---
        public async Task<GenericResponseDto> AgregarAlCarritoAsync(string token, int idProducto, int cantidad)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var itemDto = new CarritoItemCreateDto
            {
                IdProducto = idProducto,
                Cantidad = cantidad
            };

            var json = JsonConvert.SerializeObject(itemDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/Carrito/agregar", content);

                if (response.IsSuccessStatusCode)
                {
                    return new GenericResponseDto { Exitoso = true, Mensaje = "Producto agregado al carrito." };
                }
                else
                {
                    // Intentamos leer el error de la API
                    var jsonRes = await response.Content.ReadAsStringAsync();
                    try
                    {
                        var res = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRes);
                        return new GenericResponseDto { Exitoso = false, Mensaje = res.Mensaje ?? "Error al agregar." };
                    }
                    catch
                    {
                        return new GenericResponseDto { Exitoso = false, Mensaje = "Error desconocido al agregar." };
                    }
                }
            }
            catch (Exception ex)
            {
                return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message };
            }
        }

        public async Task<CarritoReadDto> GetCarritoAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.GetAsync($"{baseUrl}/Carrito");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CarritoReadDto>(json);
                }
                return null;
            }
            catch { return null; }
        }

        // Y el metodo para COMPRAR (Crear Pedido)
        public async Task<GenericResponseDto> CrearPedidoAsync(string token, string metodoPago)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var pedidoDto = new { metodoPago = metodoPago }; // Objeto anonimo para el DTO simple
            var json = JsonConvert.SerializeObject(pedidoDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/Pedidos/crear", content);
                var jsonRes = await response.Content.ReadAsStringAsync();

                // La API devuelve un PedidoReadDto si es exitoso, pero aqui solo nos importa si funciono o no
                if (response.IsSuccessStatusCode)
                {
                    return new GenericResponseDto { Exitoso = true, Mensaje = "¡Pedido realizado con exito!" };
                }
                else
                {
                    // Si fallo, intentamos leer el mensaje de error
                    try
                    {
                        var res = JsonConvert.DeserializeObject<GenericResponseDto>(jsonRes);
                        return new GenericResponseDto { Exitoso = false, Mensaje = res.Mensaje ?? "Error al comprar." };
                    }
                    catch { return new GenericResponseDto { Exitoso = false, Mensaje = "Error desconocido." }; }
                }
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

        public async Task<List<PedidoReadDto>> GetMisPedidosAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.GetAsync($"{baseUrl}/Pedidos/mis-pedidos");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PedidoReadDto>>(json);
                }
                return null;
            }
            catch { return null; }
        }

        // 2. Cancelar Pedido Completo
        public async Task<GenericResponseDto> CancelarPedidoAsync(string token, int idPedido)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.PutAsync($"{baseUrl}/Pedidos/{idPedido}/cancelar", null);
                var json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<GenericResponseDto>(json);
                res.Exitoso = response.IsSuccessStatusCode;
                return res;
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

        // 3. Devolver (Cancelar) un solo producto
        public async Task<GenericResponseDto> DevolverProductoAsync(string token, int idPedido, int idProducto)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.PutAsync($"{baseUrl}/Pedidos/{idPedido}/cancelarProducto/{idProducto}", null);
                var json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<GenericResponseDto>(json);
                res.Exitoso = response.IsSuccessStatusCode;
                return res;
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

        // --- METODOS PARA REPARTIDOR ---

        // 1. Obtener pedidos pendientes de entrega
        public async Task<List<PedidoRepartidorDto>> GetPedidosDisponiblesAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.GetAsync($"{baseUrl}/Pedidos/disponibles");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PedidoRepartidorDto>>(json);
                }
                return null;
            }
            catch { return null; }
        }

        // 2. Marcar pedido como entregado
        public async Task<GenericResponseDto> EntregarPedidoAsync(string token, int idPedido)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.PutAsync($"{baseUrl}/Pedidos/entregar/{idPedido}", null);
                var json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<GenericResponseDto>(json);
                res.Exitoso = response.IsSuccessStatusCode;
                return res;
            }
            catch (Exception ex) { return new GenericResponseDto { Exitoso = false, Mensaje = ex.Message }; }
        }

        // --- METODO PARA EL CONTADOR ---
        public async Task<List<FacturaReadDto>> GetFacturasAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                // Llamamos al endpoint del FacturasController
                var response = await client.GetAsync($"{baseUrl}/Facturas");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<FacturaReadDto>>(json);
                }
                return null;
            }
            catch { return null; }
        }

        public async Task<List<ReporteVentasDto>> GetReporteVentasAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            try
            {
                var response = await client.GetAsync($"{baseUrl}/Facturas/reporte-ventas");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ReporteVentasDto>>(json);
                }
                return new List<ReporteVentasDto>();
            }
            catch { return new List<ReporteVentasDto>(); }
        }

        public async Task<List<ReporteVentasDto>> GetReporteRangoAsync(string token, DateTime inicio, DateTime fin)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            // Formato de fecha seguro para URL
            string url = $"{baseUrl}/Facturas/reporte-rango?inicio={inicio:yyyy-MM-dd}&fin={fin:yyyy-MM-dd}";

            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ReporteVentasDto>>(json);
                }
                return new List<ReporteVentasDto>();
            }
            catch { return new List<ReporteVentasDto>(); }
        }
    }
}