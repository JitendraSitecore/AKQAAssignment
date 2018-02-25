using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AKQAAssignment.Controllers
{
    [RoutePrefix("api/converter")]
    public class AmountConverterController : ApiController
    {
        [Route("Currency/{amount:decimal}/")]
        [HttpGet]
        public string ConvertCurrencyIntoWord(decimal amount)
        {
            string result = string.Empty;
            if (amount > 0)
                result = CurrencyHandler.ConvertToWord(amount);
            else
                result = "Amount must be greater than zero";

            return result;
        }
    }
}
