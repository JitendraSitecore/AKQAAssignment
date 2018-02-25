using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AKQAAssignment.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace AKQAAssignment.Controllers
{
    [RoutePrefix("PrintCheque")]
    [Route("{action=Index}")]
    public class PrintChequeController : Controller
    {
        [Route("~/")]
        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Print Cheque";
            ChequeInfo chequeInfo = new ChequeInfo();
            return View(chequeInfo);
        }

        [HttpPost]
        [Route("IndexPost")]
        public ActionResult IndexPost(ChequeInfo chequeInfo)
        {

            string URL = string.Format("http://{0}:{1}/api/converter/Currency/{2}/",
                Request.Url.Host, Request.Url.Port, chequeInfo.Amount);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                {
                    chequeInfo.AmountInWords = stream.ReadToEnd();
                }
            }

            return View("~/Views/PrintCheque/Index.cshtml",chequeInfo);
        }

        
    }
}