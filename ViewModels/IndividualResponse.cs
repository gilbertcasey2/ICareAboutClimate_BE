using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class IndividualResponse
	{
		public string questions { get; set; }

		public IndividualResponse(string questions)
		{
			this.questions = questions;
		}
	}
}

