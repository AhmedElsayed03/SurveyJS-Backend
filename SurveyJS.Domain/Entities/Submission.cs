using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Domain.Entities
{
    public class Submission : Entity
    {
        //public int UserId { get; set; }
        //public string SubmissionText { get; set; } = string.Empty;


        //public int ChoiceId { get; set; }
        //public int ElementId { get; set; }
        //public Choice? Choice { get; set; }
        //public Element? Element { get; set; }

        
        public string ElementName { get; set; } = string.Empty;
        public string ChoiceName { get; set; } = string.Empty;

    }
}
