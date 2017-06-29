using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DWX17.Workshop.WebApp.Middlewares
{
    public static class ConditionalMiddleware
    {
        public static IApplicationBuilder UseWhen(this IApplicationBuilder app, Func<HttpContext, bool> condition, Action<IApplicationBuilder> configuration)
        {
            IApplicationBuilder builder = app.New();
            configuration(builder);

            return app.Use(next =>
            {
                builder.Run(next);

                var branch = builder.Build();

                return context => condition(context) ? branch(context) : next(context);
            });
        }
    }
}