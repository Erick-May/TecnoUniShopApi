namespace TecnoUniShopApi.DTOs
{
    public class ReporteVentasDto
    {
        public string Producto { get; set; }
        public int TotalVendido { get; set; }

        //Para las ventas por fecha
        public string Categoria { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal TotalIngresos { get; set; }
    }
}
