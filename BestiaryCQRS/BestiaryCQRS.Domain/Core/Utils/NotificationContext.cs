using BestiaryCQRS.Domain.Core.Dto;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace BestiaryCQRS.Domain.Core.Utils
{
    public class NotificationContext
    {
        private readonly List<Notification> notifications;
        public IReadOnlyCollection<Notification> Notifications => notifications;
        public bool HasNotifications => notifications.Any();

        public NotificationContext()
        {
            notifications = new List<Notification>();
        }

        public void AddNotification(string key, string message)
        {
            notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            this.notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            this.notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            this.notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
