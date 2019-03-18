using System.ComponentModel.DataAnnotations;

namespace HangFireExamples.Models
{
    public class SendEmailRequestModel
    {
        [Required]
        public string Email { get; set; }
    }
}
