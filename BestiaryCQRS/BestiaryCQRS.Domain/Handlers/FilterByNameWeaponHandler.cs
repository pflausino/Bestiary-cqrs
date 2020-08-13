using System;
using System.Linq;
using System.Threading.Tasks;
using BestiaryCQRS.Domain.Core.Utils;
using BestiaryCQRS.Domain.Entities;
using BestiaryCQRS.Domain.Interfaces;
using BestiaryCQRS.Domain.Queries;
using NHibernate;

namespace BestiaryCQRS.Domain.Handlers
{
    public class FilterByNameWeaponHandler : IFilterByNameWeaponHandler
    {
        private readonly ISession session;
        private readonly NotificationContext notificationContext;

        public FilterByNameWeaponHandler(ISession session, NotificationContext notificationContext)
        {
            this.session = session;
            this.notificationContext = notificationContext;
        }
        public async Task<IQueryable<Weapon>> Handler(FilterByNameQuery parameters)
        {
            if (parameters.Invalid)
            {
                notificationContext.AddNotifications(parameters.ValidationResult);
                return null;
            }

            var result = session.Query<Weapon>()
                                    .Where(x => x.Name.Contains(parameters.Name));
            return result;

        }
    }
}