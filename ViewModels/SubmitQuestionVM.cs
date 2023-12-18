using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class SubmitQuestionVM
	{
        public Guid userID {get; set;}
		public int questionIndex { get; set; }

        public int answerIndex {get; set; }

		public SubmitQuestionVM(Guid userID, int questionIndex, int answerIndex)
		{
			this.userID = userID;
            this.questionIndex = questionIndex;
            this.answerIndex = answerIndex;
		}
	}
}