using System;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Interfaces;
using BestiaryCQRS.Domain.Core.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestiaryCQRS.Api.Filters
{
    public class MongoUnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        public MongoUnitOfWorkFilter(NotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                await next.Invoke();


                if (_notificationContext.HasNotifications)
                {
                    _unitOfWork.Dispose();
                }
                else
                {
                    _unitOfWork.Commit();
                }

            }
            catch (Exception)
            {



                throw;
            }
        }
    }
}