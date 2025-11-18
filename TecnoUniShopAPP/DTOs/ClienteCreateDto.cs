using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
    }
}
