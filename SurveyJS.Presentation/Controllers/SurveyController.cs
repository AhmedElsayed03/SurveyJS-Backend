using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SurveyJS.Application.Abstractions.Models.DTOs;
using SurveyJS.Application.Abstractions.Services;

namespace SurveyJS.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost("create-survey")]
        public async Task<NoContent> CreateSurveyAsync(SurveyAddDto newSurvey)
        {
            await _surveyService.CreateSurvey(newSurvey);
            return TypedResults.NoContent();
        }

        [HttpGet("render-survey")]
        public async Task<RenderSurveyDto> RenderSurveyAsync(int id)
        {
            RenderSurveyDto renderSurvey = await _surveyService.RenderSurvey(id);
            return renderSurvey;
        }
    }
}
