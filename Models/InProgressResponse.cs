using System;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICareAboutClimateBE.Models
{
    [Owned]
	public class InProgressResponse
    {
        [Key]
        public int progressId {get; set;}
		public int questionIndex { get; set; }

        public int? answerIndex {get; set;}
		public string? answerIndexes { get; set; }

        public string? otherAnswer {get; set;}

        public bool? isFinalResponse {get; set;}

        public bool isMultipleChoice {get; set;}

        public DateTime timeStamp {get; set;}

        public virtual FormResponse formResponse {get; set;}

        public InProgressResponse(int questionIndex)
        {
            this.questionIndex = questionIndex;
            formResponse = new FormResponse();
            isFinalResponse = false;
        }
    }
}