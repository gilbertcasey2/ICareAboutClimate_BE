using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class IndividualResponseVM
	{
		public string questions { get; set; }

		public IndividualResponseVM(string questions)
		{
			this.questions = questions;
		}
	}
}

