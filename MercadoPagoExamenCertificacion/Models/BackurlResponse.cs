using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoPagoExamenCertificacion.Models
{
    public class BackurlResponse
    {
        public string strCollectionId { get; set; }
        public string strCollectionStatus { get; set; }
        public string strPaymentId { get; set; }
        public string strStatus { get; set; }
        public string strExternalReference { get; set; }
        public string strPaymentType { get; set; }
        public string strPreferenceId { get; set; }
        public string strSiteId { get; set; }
        public string strProcesssingMode { get; set; }
        public string strMerchantAccountId { get; set; }
        public string strMerchantOrderId { get; set; }
        public string strPage { get; set; }
    }
}
