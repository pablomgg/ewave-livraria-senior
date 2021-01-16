using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Services;
using ToDo.WebApi.Filters;

namespace ToDo.WebApi.Configurations
{
    [ExceptionActionFilter]
    public class WriteApiBase : ControllerBase
    {
        protected readonly IDomainService DomainService;

        public WriteApiBase(IDomainService domainService)
        {
            DomainService = domainService;
        }
    }
}
