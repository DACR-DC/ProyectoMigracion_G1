namespace ApiERP.Models.Templates
{
    public class InvoiceP
    {
        public int NoFactura { get; set; }
        public string NombreProvFacxPag { get; set; }
        public string NitProvFacxPag { get; set; }
        public DateTime FechaVencFacxPag { get; set; }
        public DateTime FechaAbono { get; set; }
        public double SubtotalFacxPag { get; set; }
        public double IvaFacxPag { get; set; }
        public double TotalFacxPag { get; set; }
        public int EstadoFacxPag { get; set; }
        public string NotasFacxPag { get; set; }
        public int TblEncabezadoComprasIdEncComp { get; set; }

        public InvoiceP(int noFactura, string nombreProvFacxPag, string nitProvFacxPag, DateTime fechaVencFacxPag, DateTime fechaAbono, double subtotalFacxPag, double ivaFacxPag, double totalFacxPag, int estadoFacxPag, string notasFacxPag, int tblEncabezadoComprasIdEncComp)
        {
            NoFactura = noFactura;
            NombreProvFacxPag = nombreProvFacxPag;
            NitProvFacxPag = nitProvFacxPag;
            FechaVencFacxPag = fechaVencFacxPag;
            FechaAbono = fechaAbono;
            SubtotalFacxPag = subtotalFacxPag;
            IvaFacxPag = ivaFacxPag;
            TotalFacxPag = totalFacxPag;
            EstadoFacxPag = estadoFacxPag;
            NotasFacxPag = notasFacxPag;
            TblEncabezadoComprasIdEncComp = tblEncabezadoComprasIdEncComp;
        }
    }
}
