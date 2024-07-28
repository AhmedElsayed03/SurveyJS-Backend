using Azure;
using SurveyJS.Application.Abstractions.Models.DTOs;
using SurveyJS.Application.Abstractions.Services;
using SurveyJS.Application.Abstractions.UnitOfWork;
using SurveyJS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace SurveyJS.Infrastructure.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SurveyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateSurvey(SurveyAddDto newSurvey)
        {
            //Survey JSON
            Survey survey = new Survey()
            {

                Title = newSurvey.Title,
                Description = newSurvey.Description,
                CreateTime = DateTime.Now,

            };
            await _unitOfWork.SurveyRepo.AddAsync(survey);
            await _unitOfWork.SaveChangesAsync();

            //Pages JSON
            foreach (var p in newSurvey.Pages)
            {
                Page page = new Page
                {
                    Name = p.Name,
                    Title = p.Title,
                    Description = p.Description,
                    SurevyId = survey.Id,
                    CreateTime = DateTime.Now,
                };
                await _unitOfWork.PageRepo.AddAsync(page);
                await _unitOfWork.SaveChangesAsync();


                //Elements JSON
                foreach (var e in p.Elements)
                {
                    Element element = new Element
                    {
                        Title = e.Title,
                        Name = e.Name,
                        Type = e.Type,
                        IsRequired = e.IsRequired,
                        VisibleIf = e.VisibleIf,
                        PageId = page.Id,
                        CreateTime = DateTime.Now
                    };
                    await _unitOfWork.ElementRepo.AddAsync(element);
                    await _unitOfWork.SaveChangesAsync();


                    //Choices JSON
                    foreach (var c in e.Choices)
                    {
                        Choice choice = new Choice
                        {
                            Value = c.Value,
                            Text = c.Text,
                            ElementId = element.Id,
                            CreateTime = DateTime.Now
                        };
                        await _unitOfWork.ChoiceRepo.AddAsync(choice);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
            }


        }

        public async Task<RenderSurveyDto> RenderSurvey(int id)
        {
            Survey? survey = await  _unitOfWork.SurveyRepo.GetByIdAsync(id);

            RenderSurveyDto renderSurvey = new RenderSurveyDto
            {
                Title = survey!.Title,
                Description = survey.Description
            };

            foreach (var p in renderSurvey.Pages)
            {
                PagewithElementsAddDto page = new PagewithElementsAddDto
                {
                    Name = p.Name,
                    Title = p.Title,
                    Description = p.Description
                };


                //Elements JSON
                foreach (var e in p.Elements)
                {
                    ElementWithChoicesAddDto element = new ElementWithChoicesAddDto
                    {
                        Title = e.Title,
                        Name = e.Name,
                        Type = e.Type,
                        IsRequired = e.IsRequired,
                        VisibleIf = e.VisibleIf
                    };


                    //Choices JSON
                    foreach (var c in e.Choices)
                    {
                        ChoiceAddDto choice = new ChoiceAddDto
                        {
                            Value = c.Value,
                            Text = c.Text
                        };
                    }
                }
            }

            return renderSurvey;

        }
    }
}
