using SurveyJS.Application.Abstractions.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Application.Abstractions.Services
{
    public interface ISurveyService
    {
        //Create Survey [Admin]
        Task CreateSurvey(SurveyAddDto newSurvey);

        //Get Survey [User]
        Task<RenderSurveyDto> RenderSurvey(int id);
        
        //Submit Survey [User]


        //Submit Survey [User]
    }
}
