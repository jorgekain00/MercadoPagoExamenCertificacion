using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MercadoPagoExamenCertificacion.Models;
using Microsoft.AspNetCore.Mvc;
// SDK de Mercado Pago
using MercadoPago.Config;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Options;

namespace MercadoPagoExamenCertificacion.Controllers
{
    public class DetailController : Controller
    {
        private IOptions<MercadoPagoSiteConfig> _mercadoPagoSiteConfig;

        public DetailController(IOptions<MercadoPagoSiteConfig> mercadoPagoSiteConfig)
        {
            _mercadoPagoSiteConfig = mercadoPagoSiteConfig;
        }

        public IActionResult Index()
        {
            // Agrega credenciales MP
            MercadoPagoConfig.AccessToken = _mercadoPagoSiteConfig.Value.AccessToken;
            // Agrega el integrador.
            MercadoPagoConfig.IntegratorId = _mercadoPagoSiteConfig.Value.IntegratorId;
            // Obtiene la OC de compra
            OrdenCompra objOC = new OrdenCompra();
            objOC.strImagen = Request.Form["img"].ToString();
            objOC.strProducto = Request.Form["title"].ToString();
            objOC.intUnidades = Convert.ToInt32(Request.Form["unit"].ToString());
            objOC.decPrice = Convert.ToDecimal(Request.Form["price"].ToString());

            //Genera la preferencia
            // Crea el objeto de request de la preference
            var objRequest = new PreferenceRequest();
            objRequest.Items = new List<PreferenceItemRequest>
                {
                    new PreferenceItemRequest
                    {
                        Id = "1234",
                        Title = objOC.strProducto,
                        Description= "Dispositivo móvil de Tienda e-commerce",
                        Quantity = objOC.intUnidades,
                        CurrencyId = "MXN",
                        UnitPrice = objOC.decPrice,
                        PictureUrl = $"{_mercadoPagoSiteConfig.Value.Domain}{objOC.strImagen.Substring(2)}",
                        CategoryId = "phones",
                    },
                };

            objRequest.Payer = new PreferencePayerRequest()
            {
                Name = "Lalo",
                Surname = "Landa",
                Email = _mercadoPagoSiteConfig.Value.TestUserEmail,
                Phone = new MercadoPago.Client.Common.PhoneRequest()
                {
                    AreaCode = "11",
                    Number = "22223333"
                },
                Address = new MercadoPago.Client.Common.AddressRequest()
                {
                    StreetName = "Falsa",
                    StreetNumber = "123",
                    ZipCode = "1111"
                }
            };
            objRequest.BackUrls = new PreferenceBackUrlsRequest()
            {
                Success = $"{_mercadoPagoSiteConfig.Value.Domain}{_mercadoPagoSiteConfig.Value.SuccessURL}",
                Failure = $"{_mercadoPagoSiteConfig.Value.Domain}{_mercadoPagoSiteConfig.Value.FailureURL}",
                Pending = $"{_mercadoPagoSiteConfig.Value.Domain}{_mercadoPagoSiteConfig.Value.PendingURL}"
            };
            objRequest.AutoReturn = "approved";
            //objRequest.PaymentMethods = new PreferencePaymentMethodsRequest()
            //{
            //    ExcludedPaymentMethods = new List<PreferencePaymentMethodRequest>()
            //        {
            //            new PreferencePaymentMethodRequest()
            //            {
            //                Id = "amex"
            //            }
            //        },
            //    ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>()
            //        {
            //            new PreferencePaymentTypeRequest()
            //            {
            //                Id = "atm"
            //            }
            //        },
            //    Installments = 6
            //};
            objRequest.NotificationUrl = $"{_mercadoPagoSiteConfig.Value.Domain}{_mercadoPagoSiteConfig.Value.NotificationUrl}";
            objRequest.StatementDescriptor = "Certificación Mercado Pago";
            objRequest.ExternalReference = _mercadoPagoSiteConfig.Value.Email;

            // Crea la preferencia usando el client.
            var objClient = new PreferenceClient();
            Preference objPreference = objClient.Create(objRequest);
            // obtiene el resultado crear la preferencia.
            objOC.strPreferenceId = objPreference.Id;
            objOC.strInitPoint = objPreference.InitPoint;

            return View("Detail", objOC);
        }

    }
}