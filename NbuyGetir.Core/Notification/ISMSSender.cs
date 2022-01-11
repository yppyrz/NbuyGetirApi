using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notification
{
    public interface ISMSSender
    {
        /// <summary>
        /// Hangi telefon numarasına hangi mesajı atacağımızı bu servis ile yapacağız. Twilio adlı paketi kullanacağız.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendSmsAsync(string phoneNumber, string subject, string message);
    }
}
