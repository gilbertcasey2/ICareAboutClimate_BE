using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class SubmitQuestionVM
	{
        public Guid userID {get; set;}
		public int questionIndex { get; set; }

        public int answerIndex {get; set; }

		public int formIndex {get; set;}

		public SubmitQuestionVM(Guid userID, int questionIndex, int answerIndex, int formIndex)
		{
			this.userID = userID;
            this.questionIndex = questionIndex;
            this.answerIndex = answerIndex;
			this.formIndex = formIndex;
		}
	}
}