using System;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Utils;
using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;

namespace BestiaryCQRS.Api.Filters
{
    public class NHibernateSessionFilter : IAsyncActionFilter
    {
        private readonly NotificationContext _notificationContext;
        private readonly ISession _session;
        public NHibernateSessionFilter(ISession session, NotificationContext notificationContext)
        {
            _session = session;
            _notificationContext = notificationContext;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _session.BeginTransaction();
            var transaction = _session.Transaction;

            try
            {
                await next.Invoke();


                if (_notificationContext.HasNotifications && transaction.IsActive && !transaction.WasCommitted)
                {
                    transaction.Rollback();
                }
                else if (transaction.IsActive && !transaction.WasCommitted)
                {
                    transaction.Commit();
                }

            }
            catch (Exception)
            {
                if (transaction.IsActive && !transaction.WasRolledBack)
                {
                    transaction.Rollback();
                }

                throw;
            }

        }
    }
}