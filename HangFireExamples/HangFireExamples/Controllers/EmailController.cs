using Hangfire;
using HangFireExamples.Models;
using HangFireExamples.Servicies;
using Microsoft.AspNetCore.Mvc;

namespace HangFireExamples.Controllers
{
    [Produces("application/json")]
    [Route("api/email")]
    public class EmailController : Controller
    {
        [HttpPost]
        public IActionResult SendEmail([FromBody] SendEmailRequestModel model)
        {
            EmailService.SendEmailToClient(model.Email);
            EmailService.SendEmailToManager(model.Email);

            return Ok();
        }

        [HttpPost]
        [Route("hangfire")]
        public IActionResult SendEmailWithHangFire([FromBody] SendEmailRequestModel model)
        {
            BackgroundJob.Enqueue(() => EmailService.SendEmailToManager(model.Email));
            BackgroundJob.Enqueue(() => EmailService.SendEmailToClient(model.Email));

            return Ok();
        }
    }
}