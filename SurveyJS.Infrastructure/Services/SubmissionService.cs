using Azure.Core.Serialization;
using Newtonsoft.Json;
using SurveyJS.Application.Abstractions.Models.DTOs;
using SurveyJS.Application.Abstractions.Repositories;
using SurveyJS.Application.Abstractions.Services;
using SurveyJS.Application.Abstractions.UnitOfWork;
using SurveyJS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Infrastructure.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public async Task SubmitSurvey(SubmissionAddDto newSubmission) 
        //{
        //    Submission submission = new Submission()
        //    {
        //        ChoiceId = newSubmission.ChoiceId,
        //        ElementId = newSubmission.ElementId,
        //        CreateTime = DateTime.Now,
        //    };

        //    var choice = await _unitOfWork.ChoiceRepo.GetByIdAsync(submission.ChoiceId);
        //    submission.SubmissionText = choice!.Text;


        //    await _unitOfWork.SubmissionRepo.AddAsync(submission);
        //    await _unitOfWork.SaveChangesAsync();
        //}

        public async Task SubmitSurvey(SubmissionAddDto newSubmission)
        {



            //string jsonString = JsonConvert.SerializeObject(newSubmission); 

            // Deserialize JSON to DynamicDto
            //var dynamicDto = JsonConvert.DeserializeObject<SubmissionAddDto>(jsonString);

            // Access data
            foreach (var kvp in newSubmission.Data)
            {
                Submission submission = new Submission()
                {
                    ElementName = kvp.Key,
                    ChoiceName = kvp.Value.ToString(),
                    CreateTime = DateTime.Now,
                };

                await _unitOfWork.SubmissionRepo.AddAsync(submission);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
