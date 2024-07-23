﻿using SurveyJS.Application.Abstractions.Repositories;
using SurveyJS.Domain.Entities;
using SurveyJS.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Infrastructure.Data.Repositories
{
    public class ElementRepo : GenericRepo<Element>, IElementRepo
    {
        private readonly SurveyDbContext _dbContext;

        public ElementRepo(SurveyDbContext context) : base(context)
        {
            _dbContext = context;
        }


    }
}
