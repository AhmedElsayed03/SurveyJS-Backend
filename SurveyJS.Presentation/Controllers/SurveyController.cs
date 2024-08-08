using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SurveyJS.Application.Abstractions.Models.DTOs;
using SurveyJS.Application.Abstractions.Services;

namespace SurveyJS.Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly ISubmissionService _submissionService;
        public SurveyController(ISurveyService surveyService, ISubmissionService submissionService)
        {
            _surveyService = surveyService;
            _submissionService = submissionService;
        }

        [HttpPost("create-survey")]
        public async Task<NoContent> CreateSurveyAsync(SurveyAddDto newSurvey)
        {
            await _surveyService.CreateSurvey(newSurvey);
            return TypedResults.NoContent();
        }

        [HttpGet("render-survey/{id}")]
        public async Task<RenderSurveyDto> RenderSurveyAsync(int id)
        {
            RenderSurveyDto renderSurvey = await _surveyService.RenderSurvey(id);
            return renderSurvey;
        }

        [HttpPost("submit")]
        public async Task<NoContent> SubmitSurvey([FromBody] SubmissionAddDto newSubmission)
        {

            var jsonData = newSubmission.Data;

            Console.WriteLine(jsonData);

            await _submissionService.SubmitSurvey(newSubmission);
            return TypedResults.NoContent();
        }


        [HttpPost("submit-two")]
        public async Task<NoContent> Post([FromBody] JObject data)
        {
            // Process the dynamic JSON data here
            // You can access properties of the JObject like this:
            // var propertyValue = data["propertyName"];

            // For demonstration, we'll just return the received data


            SubmissionAddDto newSubmission = new SubmissionAddDto();
            await _submissionService.SubmitSurvey(newSubmission);
            return TypedResults.NoContent();
        }
    }
}
