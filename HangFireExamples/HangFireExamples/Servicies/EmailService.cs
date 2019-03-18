using System;
using System.Threading;
using Hangfire;

namespace HangFireExamples.Servicies
{
    public static class EmailService
    {
        [Queue("critical")]
        [AutomaticRetry(Attempts = 10)]
        public static void SendEmailToClient(string email)
        {
            Thread.Sleep(5000);
        }

        [Queue("default")]
        [AutomaticRetry(Attempts = 4)]
        public static void SendEmailToManager(string email)
        {
            Thread.Sleep(5000);
        }
    }
}
