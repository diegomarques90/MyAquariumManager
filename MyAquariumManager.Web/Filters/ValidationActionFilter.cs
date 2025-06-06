using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyAquariumManager.Web.Filters
{
    public class ValidationActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }


            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null)
                    continue;

                var validator = context.HttpContext.RequestServices.GetService(typeof(IValidator<>).MakeGenericType(argument.GetType())) as IValidator;

                if (validator == null)
                    continue;

                var validationContext = new ValidationContext<object>(argument);

                var validationResult = await validator.ValidateAsync(validationContext, context.HttpContext.RequestAborted);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                        context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                 
                    context.Result = new BadRequestObjectResult(context.ModelState);
                    return;
                }
            }

            await next();
        }
    }
}
