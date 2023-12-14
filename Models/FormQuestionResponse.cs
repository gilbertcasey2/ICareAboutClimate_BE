using System;
using Newtonsoft.Json.Linq;

namespace ICareAboutClimateBE.Models
{
	public class FormQuestionResponse
    {
		public int questionNumber { get; set; }
		public int answer { get; set; }

        public FormQuestionResponse(int questionNumber, int answer)
        {
            this.questionNumber = questionNumber;
            this.answer = answer;
        }
    }
}

