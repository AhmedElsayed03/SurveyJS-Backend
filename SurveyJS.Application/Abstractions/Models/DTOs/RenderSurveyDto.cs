using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Application.Abstractions.Models.DTOs
{
    public class RenderSurveyDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<PagewithElementsAddDto> Pages { get; set; } = new List<PagewithElementsAddDto>();
    }
}
