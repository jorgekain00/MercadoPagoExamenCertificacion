using MercadoPagoExamenCertificacion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoPagoExamenCertificacion.Controllers
{
    public class BackurlController : Controller
    {
        public IActionResult Success()
        {
            BackurlResponse objBR = ObtieneLlaves(Request, "Success");
            return View("Backurl", objBR);
        }

        public IActionResult Failure()
        {
            BackurlResponse objBR = ObtieneLlaves(Request, "Failure");
            return View("Backurl", objBR);
        }
        public IActionResult Pending()
        {
            BackurlResponse objBR = ObtieneLlaves(Request, "Pending");
            return View("Backurl", objBR);
        }

        private BackurlResponse ObtieneLlaves(HttpRequest Request, string strController)
        {
            var objQS = Request.Query;
            BackurlResponse objBR = new BackurlResponse();
            objBR.strPage = strController;
            if (Request.QueryString.HasValue)
            {
                if (!string.IsNullOrEmpty(objQS["collection_id"]))
                {
                    objBR.strCollectionId = objQS["collection_id"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["collection_status"]))
                {
                    objBR.strCollectionStatus = objQS["collection_status"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["payment_id"]))
                {
                    objBR.strPaymentId = objQS["payment_id"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["status"]))
                {
                    objBR.strStatus = objQS["status"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["external_reference"]))
                {
                    objBR.strExternalReference = objQS["external_reference"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["merchant_account_id"]))
                {
                    objBR.strMerchantAccountId = objQS["merchant_account_id"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["payment_type"]))
                {
                    objBR.strPaymentType = objQS["payment_type"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["merchant_order_id"]))
                {
                    objBR.strMerchantOrderId = objQS["merchant_order_id"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["preference_id"]))
                {
                    objBR.strPreferenceId = objQS["preference_id"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["processing_mode"]))
                {
                    objBR.strProcesssingMode = objQS["processing_mode"].ToString();
                }
                if (!string.IsNullOrEmpty(objQS["site_id"]))
                {
                    objBR.strSiteId = objQS["site_id"].ToString();
                }
            }

            return objBR;
        }
    }
}
