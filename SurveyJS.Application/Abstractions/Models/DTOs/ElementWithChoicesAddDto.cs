using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Application.Abstractions.Models.DTOs
{
    public class ElementWithChoicesAddDto
    {
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public bool IsRequired { get; set; } = false;
        public string VisibleIf { get; set; } = string.Empty;
        public IEnumerable<ChoiceAddDto> Choices { get; set; } = new List<ChoiceAddDto>();
    }
}
