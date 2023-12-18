using System;
namespace ICareAboutClimateBE.Models
{
	public class FormResponse
	{
        public List<FormQuestionResponse>? responses { get; set; }

        public bool isCompleted { get; set; }

        public int? formIndex {get; set; }

        public Guid storeageID {get; set;}
    }
}

