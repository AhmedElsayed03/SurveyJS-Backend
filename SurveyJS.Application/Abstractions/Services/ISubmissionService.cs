using SurveyJS.Application.Abstractions.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Application.Abstractions.Services
{
    public interface ISubmissionService
    {
        Task SubmitSurvey(SubmissionAddDto newSubmission);
    }
}
