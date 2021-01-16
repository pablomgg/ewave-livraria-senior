using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Dapper.Abstractions.Models;

namespace ToDo.Dapper.Abstractions.Finders
{
    public interface IInstituicaoDeEnsinoFinder
    {
        Task<IEnumerable<InstituicaoDeEnsinoModel>> ObterAsync();
        Task<InstituicaoDeEnsinoModel> ObterAsync(Guid aggregateId);
    }
}