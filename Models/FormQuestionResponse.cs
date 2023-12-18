using System;
using Newtonsoft.Json.Linq;

namespace ICareAboutClimateBE.Models
{
	public class FormQuestionResponse
    {
        public int id {get; set;}
		public int questionIndex { get; set; }
		public int answerIndex { get; set; }

        public bool? isFinalResponse {get; set;}

        public DateTime timeStamp {get; set;}

        public FormQuestionResponse(int questionIndex, int answerIndex, DateTime timeStamp)
        {
            this.questionIndex = questionIndex;
            this.answerIndex = answerIndex;
            this.timeStamp = timeStamp;
        }
    }
}