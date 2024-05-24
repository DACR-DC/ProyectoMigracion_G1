namespace ApiERP.Models.Templates
{
    public class FacturaPorCobrar
    {
        // Atributos
        public int NoFactura { get; set; }
        public decimal Total { get; set; }
        public DateTime TiempoPago { get; set; }
        public string Estado { get; set; }
        public int IdVentaDetalle { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal FaltantePago { get; set; }

        // Constructor
        public FacturaPorCobrar(int noFactura, decimal total, DateTime tiempoPago, string estado, int idVentaDetalle, int idCliente, DateTime fechaFactura, decimal faltantePago)
        {
            NoFactura = noFactura;
            Total = total;
            TiempoPago = tiempoPago;
            Estado = estado;
            IdVentaDetalle = idVentaDetalle;
            IdCliente = idCliente;
            FechaFactura = fechaFactura;
            FaltantePago = faltantePago;
        }

        // Constructor sin parámetros (opcional)
        public FacturaPorCobrar()
        {
            // Puedes inicializar los atributos con valores predeterminados si lo deseas
            NoFactura = 0;
            Total = 0;
            TiempoPago = DateTime.MinValue;
            Estado = "";
            IdVentaDetalle = 0;
            IdCliente = 0;
            FechaFactura = DateTime.MinValue;
            FaltantePago = 0;
        }
    }

}
