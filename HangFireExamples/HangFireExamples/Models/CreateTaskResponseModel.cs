namespace HangFireExamples.Models
{
    public class CreateTaskResponseModel
    {
        public string Id { get; set; }

        public CreateTaskResponseModel(string id)
        {
            Id = id;
        }
    }
}
