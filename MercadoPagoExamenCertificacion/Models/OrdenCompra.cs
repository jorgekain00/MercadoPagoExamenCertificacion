using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoPagoExamenCertificacion.Models
{
    public class OrdenCompra
    {
        public string strInitPoint { get; set; }
        public string strPreferenceId { get; set; }
        public string strImagen { get; set; }
        public string strProducto { get; set; }
        public int intUnidades { get; set; }
        public decimal decPrice { get; set; }
    }
}
