using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notification
{
    public interface IPushNotificationService
    {
        /// <summary>
        /// Mobil uygulamayı bir kullanıcı indirince, user hesabında deviceid tutacağız. One Signal ile kişinin cihazına bilgidirm göndereceğiz.
        /// AppId uygulamayı indiren kullanıcıya one signel tarafından verilen id.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendPushNotificationAsync(string appId, string message);
    }
}
