using SurveyJS.Application.Abstractions.Repositories;
using SurveyJS.Application.Abstractions.UnitOfWork;
using SurveyJS.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISurveyRepo SurveyRepo { get; }
        public IElementRepo ElementRepo { get; }
        public IChoiceRepo ChoiceRepo { get; }
        public IPageRepo PageRepo { get; }


        private readonly SurveyDbContext _context;

        public UnitOfWork(SurveyDbContext context,
                          ISurveyRepo surveyRepo,
                          IElementRepo questionRepo,
                          IChoiceRepo choiceRepo,
                          IPageRepo submissionRepo)
        {
            _context = context;
            SurveyRepo = surveyRepo;
            ElementRepo = questionRepo;
            ChoiceRepo = choiceRepo;
            PageRepo = submissionRepo;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
