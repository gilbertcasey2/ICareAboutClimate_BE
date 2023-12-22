using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class SubmitQuestionVM
	{
        public Guid userID {get; set;}
		public int questionIndex { get; set; }

		public int formIndex {get; set;}
		public int answerIndex { get; set; }

		public bool multipleOptions {get; set;}
		public string? otherAnswer {get; set;}

		public SubmitQuestionVM(Guid userID, int questionIndex, int answerIndex, int formIndex, bool multipleOptions, string? otherAnswer = null)
		{
			this.userID = userID;
            this.questionIndex = questionIndex;
            this.answerIndex = answerIndex;
			this.formIndex = formIndex;
			this.multipleOptions = multipleOptions;
			this.otherAnswer = otherAnswer;
		}
	}
}