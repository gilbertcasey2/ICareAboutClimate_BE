using System;
namespace ICareAboutClimateBE.Models
{
	public class FormResponse
	{
        public int id {get; set;}
        public virtual List<FormQuestionResponse> responses { get; set; }

        public virtual List<InProgressResponse> inProgressResponses { get; set; }

        public bool isCompleted { get; set; }

        public int? formIndex {get; set; }

        public Guid storeageID {get; set;}

        public DateTime arrivalTimeStamp {get; set;}

        public FormResponse() {
            responses = new List<FormQuestionResponse>();
            inProgressResponses = new List<InProgressResponse>();
        }
    }
}
