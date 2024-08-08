using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Domain.Entities
{
    public class Choice : Entity
    {
        public string Value { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;


        //Nav Props
        public Element Element { get; set; } = null!;
        public int ElementId { get; set; }
        public IEnumerable<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
