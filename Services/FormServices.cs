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

            if (sent_question == null) {
                throw new ApplicationException("Didn't receive responses.");
            }

            DateTime currentTime = DateTime.Now;
            FormQuestionResponse new_response = new(sent_question.questionIndex)
            {
                isFinalResponse = false,
                timeStamp = currentTime,
                otherAnswer = sent_question.otherAnswer,
                isMultipleChoice = sent_question.multipleOptions,
                answerIndex = sent_question.answerIndex
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

            DateTime currentTime = DateTime.Now;

            foreach(FormQuestionResponse resp in q_response.responses) {
                bool found = existingResponse.responses.Any(p => p.questionIndex == resp.questionIndex);
                if (found) {
                    continue;
                }
                if (resp.isMultipleChoice) {
                    FormQuestionResponse compiledResponse = new FormQuestionResponse(resp.questionIndex) {
                        isMultipleChoice = true
                    };
                    String answerIndexString = "";
                    foreach(FormQuestionResponse q_resp in q_response.responses.Where(p => p.questionIndex == resp.questionIndex)){
                        String? newAnswerString = q_resp.answerIndex.ToString() + ",";
                        if (newAnswerString == null) continue;
                        else if (!answerIndexString.Contains(newAnswerString)) {
                            answerIndexString = answerIndexString + newAnswerString;
                        } else {
                            answerIndexString = answerIndexString.Replace(newAnswerString, "");
                        }
                        if (q_resp.otherAnswer != null) {
                            compiledResponse.otherAnswer = q_resp.otherAnswer;
                        }
                    }
                    compiledResponse.answerIndexes = answerIndexString;
                    compiledResponse.isFinalResponse = true;
                    compiledResponse.timeStamp = currentTime;
                    existingResponse.responses.Add(compiledResponse);
                } else {
                    resp.isFinalResponse = true;
                    resp.timeStamp = currentTime;
                    existingResponse.responses.Add(resp);
                }
            }

            existingResponse.isCompleted = true;
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