using System;
using ICareAboutClimate.DataAccess;
using ICareAboutClimateBE.Models;
using ICareAboutClimateBE.ViewModels;
using Newtonsoft.Json;

namespace ICareAboutClimateBE.Services
{
    public interface IFormServices
    {
        void ResponseArrival(ArrivedResponseVM response);
        void SubmitQuestion(SubmitQuestionVM question);
        void SubmitForm(IndividualResponseVM response);
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

        public void SubmitQuestion(SubmitQuestionVM sent_question) {
            DateTime currentTime = DateTime.Now;
            FormQuestionResponse new_response = new(sent_question.questionIndex, sent_question.answerIndex, currentTime)
            {
                isFinalResponse = false
            };

            var existingForm = getOrMakeFormResponse(sent_question.userID, sent_question.formIndex);

            existingForm.inProgressResponses.Add(new_response);
            _context.SaveChanges();
            
        }

        public void SubmitForm(IndividualResponseVM response) {
            string sent_questions = response.questions;

            FormResponse? q_response = JsonConvert.DeserializeObject<FormResponse>(sent_questions);

            

            if (q_response == null) {
                throw new ApplicationException("Unable to get responses.");
            }

            FormResponse existingResponse = getOrMakeFormResponse(response.storeageID, response.formIndex);
            existingResponse.responses = q_response.responses;
            existingResponse.isCompleted = true;

            for (int i = 0; i < existingResponse.responses?.Count; i++)
            {
                existingResponse.responses[i].isFinalResponse = true;
            }

            _context.SaveChanges();
        }

        private FormResponse getOrMakeFormResponse(Guid storeageID, int formIndex)
        {
            FormResponse? existingForm = _context.formResponses.Where(x => x.storeageID == storeageID).FirstOrDefault();
            if (existingForm == null) {
                existingForm = new()
                {
                    storeageID = storeageID,
                    formIndex = formIndex
                };
                _context.formResponses.Add(existingForm);
            }
            return existingForm;
        }
	}
}