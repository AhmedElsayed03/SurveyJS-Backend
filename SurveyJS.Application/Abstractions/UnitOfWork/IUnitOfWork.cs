using SurveyJS.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyJS.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ISurveyRepo SurveyRepo { get; }
        public IElementRepo ElementRepo { get; }
        public IChoiceRepo ChoiceRepo { get; }
        public IPageRepo PageRepo { get; }


        Task<int> SaveChangesAsync();
    }
}
