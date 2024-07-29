using Microsoft.EntityFrameworkCore;
using SurveyJS.Application.Abstractions.Repositories;
using SurveyJS.Domain.Entities;
using SurveyJS.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Infrastructure.Data.Repositories
{
    public class SurveyRepo : GenericRepo<Survey>, ISurveyRepo
    {
        private readonly SurveyDbContext _dbContext;

        public SurveyRepo(SurveyDbContext context):base(context)
        {
            _dbContext = context;
        }

        public async Task<Survey?> GetAllDataByIdAsync(int id)
        {
            return await _dbContext.Surveys
                                 .Include(s => s.Pages)
                                 .ThenInclude(p => p.Elements)
                                 .ThenInclude(e => e.Choices)
                                 .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
