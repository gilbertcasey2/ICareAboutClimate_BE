using System;
namespace ICareAboutClimateBE.ViewModels
{
	public class ArrivedResponseVM
	{
		public Guid storeageID { get; set; }

		public int formIndex {get; set; }

		public ArrivedResponseVM(Guid storeageID, int formIndex)
		{
			this.storeageID = storeageID;
			this.formIndex = formIndex;
		}
	}
}