using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Data;
using System.Text.Json;

namespace Api
{
    public class AcademiasPost
    {
        private readonly IAcademiaData academiaData;

        public AcademiasPost(IAcademiaData academiaData)
        {
            this.academiaData = academiaData;
        }

        [FunctionName("AcademiasPost")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = "academias")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var academia = JsonSerializer.Deserialize<Academia>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var newAcademia = await academiaData.AddAcademia(academia);
            return new OkObjectResult(newAcademia);
        }
    }
}
