using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api
{
    public class AcademiasGet
    {
        private readonly IAcademiaData academiaData;
        public AcademiasGet(IAcademiaData academiaData)
        {
            this.academiaData = academiaData;
        }
        [FunctionName("AcademiasGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "academias")] HttpRequest req)
        {
            var products = await academiaData.GetAcademias();
            return new OkObjectResult(products);
        }
    }
}
