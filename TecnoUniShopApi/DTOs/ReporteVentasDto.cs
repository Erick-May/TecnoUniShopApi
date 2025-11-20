namespace TecnoUniShopApi.DTOs
{
    public class ReporteVentasDto
    {
        public string Producto { get; set; }
        public string Categoria { get; set; }

        // IMPORTANTE: Que se llame así, NO 'TotalVendido'
        public int UnidadesVendidas { get; set; }

        public decimal TotalIngresos { get; set; }
    }
}
