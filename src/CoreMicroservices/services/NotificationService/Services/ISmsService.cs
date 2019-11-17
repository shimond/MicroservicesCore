using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Services
{
    public interface ISmsService
    {
        Task SendDailyNotification();
    }
}
