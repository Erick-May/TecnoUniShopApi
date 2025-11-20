using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoUniShopAPP.DTOs
{
    public class ReporteVentasDto
    {
        public string Producto { get; set; }

        //Para las ventas por fecha
        public string Categoria { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal TotalIngresos { get; set; }
    }
}
