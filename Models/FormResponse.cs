using System;
namespace ICareAboutClimateBE.Models
{
	public class FormResponse
	{
        public List<FormQuestionResponse>? responses { get; set; }
        public int count { get; set; }

        public bool isCompleted { get; set; }
    }
}

