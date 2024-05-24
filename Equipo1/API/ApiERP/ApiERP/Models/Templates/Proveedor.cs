namespace ApiERP.Models.Templates
{
    public class Proveedor
    {
        public int IdProv { get; set; }
        public string NombreProv { get; set; }
        public string DomicilioProv { get; set; }
        public string TelefonoProv { get; set; }
        public string NitProv { get; set; }
        public string EstadoProv { get; set; }

        public Proveedor(int idProv, string nombreProv, string domicilioProv, string telefonoProv, string nitProv, string estadoProv)
        {
            IdProv = idProv;
            NombreProv = nombreProv;
            DomicilioProv = domicilioProv;
            TelefonoProv = telefonoProv;
            NitProv = nitProv;
            EstadoProv = estadoProv;
        }
    }
}
