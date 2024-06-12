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
    public class AcademiasPut
    {
        private readonly IAcademiaData academiaData;
        public AcademiasPut(IAcademiaData academiaData)
        {
            this.academiaData = academiaData;
        }
        [FunctionName("AcademiasPut")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "academias")] HttpRequest req,
            ILogger log)
        {
            //COMO EL PASS DE PYTHON
            //throw new NotImplementedException();
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var academia = JsonSerializer.Deserialize<Academia>(body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            var updatedAcademia = await academiaData.UpdateAcademia(academia);
            return new OkObjectResult(updatedAcademia);
        }
    }
}
