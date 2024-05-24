using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo_SisB.Templates
{
    public class Innvoice
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string CliNit { get; set; }
        public decimal FacMonto { get; set; }
        public string FacEstado { get; set; }
        public string FacServicio { get; set; }
        public Innvoice(int facId, DateTime facFecha, string cliNit, decimal facMonto, string facEstado, string facServicio)
        {
            Id = facId;
            Fecha = facFecha;
            CliNit = cliNit;
            FacMonto = facMonto;
            FacEstado = facEstado;
            FacServicio = facServicio;
        }
    }
}
