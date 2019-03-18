using System;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using HangFireExamples.Models;

namespace HangFireExamples.Controllers
{
    [Produces("application/json")]
    [Route("api/background")]
    public class BackgroundController : Controller
    {
        [Route("fireandforget")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateTaskResponseModel), 200)]
        public IActionResult FireAndForget()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Enqueue"));

            var response = new CreateTaskResponseModel(jobId);

            return Ok(response);
        }

        [Route("delayed")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateTaskResponseModel), 200)]
        public IActionResult Delayed()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Delayed"), 
                TimeSpan.FromMinutes(1));

            var response = new CreateTaskResponseModel(jobId);

            return Ok(response);
        }

        [Route("recurring")]
        [HttpPost]
        public IActionResult Recurring()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("AddOrUpdate"),
                Cron.Minutely);


            return Ok();
        }

        [Route("continuation")]
        [HttpPost]
        public IActionResult Continuation()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Begin"),
                TimeSpan.FromMinutes(1));

            BackgroundJob.ContinueWith(
                jobId,
                () => Console.WriteLine("End!"));

            return Ok();
        }
    }
}