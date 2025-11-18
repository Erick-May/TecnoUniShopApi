using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class GenericResponseDto
    {
        //"JsonProperty" para que C# entienda "mensaje" (minuscula)
        [Newtonsoft.Json.JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        // Lo usaremos para saber si la API dio error 400 o 200
        public bool Exitoso { get; set; }
    }
}
