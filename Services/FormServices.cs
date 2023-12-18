using System;
using Epistimology_BE.DataAccess;
using ICareAboutClimateBE.Models;
using ICareAboutClimateBE.ViewModels;

namespace ICareAboutClimateBE.Services
{
    public interface IFormServices
    {
        void ResponseArrival(ArrivedResponseVM response);
    }

    public class FormServices : IFormServices
	{
        private ClimateContext _context;

        public FormServices(ClimateContext context)
		{
            _context = context;
		}

        public void ResponseArrival(ArrivedResponseVM arrival_info)
        {
            Guid new_storeageID = arrival_info.storeageID;
            FormResponse new_response = new()
            {
                storeageID = new_storeageID,
                formIndex = arrival_info.formIndex
            };
            _context.formResponses.Add(new_response);
            _context.SaveChanges();
        }
	}
}