using Microsoft.AspNetCore.Mvc;
using ToDo.WebApi.Filters;

namespace ToDo.WebApi.Configurations
{
    [ExceptionActionFilter]
    public class ReadApiBase : ControllerBase
    {
    }
}
