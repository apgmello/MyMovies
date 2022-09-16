using Microsoft.AspNetCore.Mvc.Filters;
using MyMovies.Api.Loggger;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
using MyMovies.Repositories.Database.Interfaces;

namespace MyMovies.Api.Filters
{
    public class CustomActionFilterEndpoint : Attribute, IActionFilter
    {
        string before = null;
        IDatabaseRepository<ToWatch, ToWatchSearchDto> toWatchRepository = null;
        IDatabaseRepository<Watched, WatchedSearchDto> watchedRepository = null;
        string controller;
        long id;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string after = null;
            switch (controller)
            {
                case "ToWatch":
                    after = toWatchRepository?.Read(id)?.ToString();
                    break;
                case "Watched":
                    after = watchedRepository?.Read(id)?.ToString();
                    break;
            }

            var logger = context.HttpContext.RequestServices.GetService<LogBase>();
            
            if(after != null)
                logger?.Log($"{context.HttpContext.Request.Method} - Alterado de {before} para {after}");
            else
                logger?.Log($"{context.HttpContext.Request.Method} - {before} - Removido");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            controller = context.ActionDescriptor.RouteValues["controller"];
            id = (long)context.ActionArguments["id"];

            switch (controller)
            {
                case "ToWatch":
                    toWatchRepository = context.HttpContext.RequestServices.GetService<IDatabaseRepository<ToWatch, ToWatchSearchDto>>();
                    before = toWatchRepository?.Read(id)?.ToString();
                    break;
                case "Watched":
                    watchedRepository = context.HttpContext.RequestServices.GetService<IDatabaseRepository<Watched, WatchedSearchDto>>();
                    before = watchedRepository?.Read(id)?.ToString();
                    break;
            }

            
        }
    }
}
