using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Domain.Entities
{
    public class Element : Entity
    {
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsRequired { get; set; }
        public string VisibleIf { get; set; } = string.Empty;
        public IEnumerable<Choice> Choices { get; set; } = new List<Choice>();


        //Nav Props
        public Page Page { get; set; } = null!;
        public int PageId { get; set; }
    }
}
