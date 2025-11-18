using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class LoginResponseDto
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public string Token { get; set; }
        public string Rol { get; set; }
    }
}
