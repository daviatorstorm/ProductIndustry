using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class SiennController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = BadRequest(context.ModelState);
            }
        }
    }
}
