namespace ApiERP.Models.Templates
{
    public class Cliente
    {
        // Atributos
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Dpi { get; set; }

        // Constructor
        public Cliente(int idCliente, string nombre, string apellido, string direccion, string correo, string telefono, string DPI)
        {
            IdCliente = idCliente;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Correo = correo;
            Telefono = telefono;
            Dpi = DPI; ;
        }

        // Constructor sin parámetros (opcional)
        public Cliente()
        {
            // Puedes inicializar los atributos con valores predeterminados si lo deseas
            IdCliente = 0;
            Nombre = "";
            Apellido = "";
            Direccion = "";
            Correo = "";
            Telefono = "";
            Dpi = "";
        }
    }

}
