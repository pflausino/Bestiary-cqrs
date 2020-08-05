using BestiaryCQRS.Domain.Core.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BestiaryCQRS.Api.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            this.notificationContext = notificationContext;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonSerializer.Serialize(notificationContext.Notifications);

                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }
    }
}
