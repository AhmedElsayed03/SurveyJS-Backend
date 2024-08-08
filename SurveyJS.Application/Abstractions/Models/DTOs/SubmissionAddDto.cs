using Newtonsoft.Json.Linq;
using SurveyJS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace SurveyJS.Application.Abstractions.Models.DTOs
{
    public class SubmissionAddDto
    {
        //public int ChoiceId { get; set; }
        //public int ElementId { get; set; }
        //public string SubmissionText { get; set; } = string.Empty;
        //public string ElementName { get; set; } = string.Empty;
        //public string ChoiceName { get; set; } = string.Empty;


        public JObject Data { get; set; }


    }
}
