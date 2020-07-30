namespace BestiaryCQRS.BestiaryCQRS.Domain.Core.Dto
{
    public class NotificationDto
    {
        public NotificationDto(string message, object data)
        {
            Message = message;
            Success = false;
            Data = data;
        }

        public NotificationDto(object data)
        {
            Success = true;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

    }
}