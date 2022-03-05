using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoPagoExamenCertificacion.Models
{
    public class MercadoPagoSiteConfig
    {
        public string AccessToken { get; set; }
        public string Domain { get; set; }
        public string Email { get; set; }
        public string TestUserEmail { get; set; }
        public string SuccessURL { get; set; }
        public string FailureURL { get; set; }
        public string PendingURL { get; set; }
        public string NotificationUrl { get; set; }
        public string IntegratorId { get; set; }
    }
}
