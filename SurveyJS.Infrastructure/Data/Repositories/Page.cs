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
    public class PageRepo : GenericRepo<Page>, IPageRepo
    {
        private readonly SurveyDbContext _dbContext;

        public PageRepo(SurveyDbContext context) : base(context)
        {
            _dbContext = context;
        }


    }
}
