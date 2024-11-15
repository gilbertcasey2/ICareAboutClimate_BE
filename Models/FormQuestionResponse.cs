﻿using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace ICareAboutClimateBE.Models
{
	public class FormQuestionResponse
    {
        [Key]
        public int id {get; set;}
		public int questionIndex { get; set; }

        public int? answerIndex {get; set;}
		public string? answerIndexes { get; set; }

        public string? otherAnswer {get; set;}

        public bool? isFinalResponse {get; set;}

        public bool isMultipleChoice {get; set;}

        public DateTime timeStamp {get; set;}

        public virtual FormResponse formResponse {get; set;}

        public FormQuestionResponse(int questionIndex)
        {
            this.questionIndex = questionIndex;
            formResponse = new FormResponse();
            isFinalResponse = true;
        }
    }
}