using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoPagoExamenCertificacion.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHostingEnvironment _env;

        public NotificationController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public IActionResult PutNotify()
        {
            var strBody = new System.IO.StreamReader(Request.Body).ReadToEnd();
            var path = Path.Combine(_env.WebRootPath, "files", "notify.txt");
            //var objfile = new FileInfo(path);
            //if (objfile.Exists)
            //{
            //    objfile.Delete();
            //}
            //objfile = null;

            using (StreamWriter objwrt = new StreamWriter(path,true))
            {
                objwrt.Write(strBody);
            }


            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);
        }

        [HttpGet]
        public IActionResult GetNotify()
        {
            var path = Path.Combine(_env.WebRootPath, "files", "notify.txt");
            var objfile = new FileInfo(path);
            string strBody = string.Empty;

            if (objfile.Exists)
            {
                using (StreamReader objRdr = new StreamReader(path))
                {
                    strBody = objRdr.ReadToEnd();
                }
            }
            else
            {
                return Ok("No data");
            }
            return Ok(strBody);
        }
    }
}