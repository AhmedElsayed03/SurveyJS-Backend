using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Domain.Entities
{
    public class Page : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<Element> Elements { get; set; } = new List<Element>();

        //Nav Props
        public Survey Survey { get; set; } = null!;
        public int SurevyId { get; set; }
    }
}
