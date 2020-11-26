using Ensek.Test.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ensek.Test.Web
{
    [Route("[controller]")]
    [ApiController]
    public class MeterReadingController : Controller
    {
        private readonly IMediator mediator;

        public MeterReadingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostCsv()
        {
            var files = Request.Form.Files;

            var result = await mediator.Send(new CsvUploadCommand(files));

            return Ok(result);
        }
    }
}
