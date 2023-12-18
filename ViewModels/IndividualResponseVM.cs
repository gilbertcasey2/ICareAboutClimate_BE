using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class IndividualResponseVM
	{
		public Guid storeageID { get; set; }

		public int formIndex {get; set; }
		public string questions { get; set; }

		public IndividualResponseVM(string questions)
		{
			this.questions = questions;
		}
	}
}

