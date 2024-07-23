using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Application.Abstractions.Models.DTOs
{
    public class PagewithElementsAddDto
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ElementWithChoicesAddDto> Elements { get; set; } = new List<ElementWithChoicesAddDto>();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
