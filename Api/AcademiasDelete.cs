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
    public class AcademiasDelete
    {
        private readonly IAcademiaData academiaData;
        public AcademiasDelete(IAcademiaData academiaData)
        {
            this.academiaData = academiaData;
        }

        [FunctionName("AcademiasDelete")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "academias/{academiaId:int}")] HttpRequest req, int academiaId, ILogger log)
        {
            var result = await academiaData.DeleteAcademia(academiaId);
            if (result)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
