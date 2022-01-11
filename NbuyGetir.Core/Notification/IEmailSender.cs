using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Notification
{
    public class EmailtAttachment
    {
        /// <summary>
        /// Base64 formatında veri, resim, excel,word vs dosyalar olabilir.
        /// </summary>
        public string Base64 { get; set; }
        /// <summary>
        /// Dosya byte[] olarakda email saf halde gönderilir.
        /// </summary>
        public byte[] File { get; set; }
    }

    public interface IEmailSender
    {
        /// <summary>
        /// E-Mail atma işlemleri için bu servisi kullanacağız.
        /// </summary>
        /// <param name="to">Aralarında , olarak tek bir string ile birden fazla kişiye mail atılabilir. (x@gmail,y@gmail etc.)</param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="cc">Aralarına , konularak birden fazla kişi cc eklenebilir.</param>
        /// <param name="emailtAttachments"></param>
        /// <returns></returns>
        Task SendSingleEmailAsync(string to, string subject, string message, string cc,List<EmailtAttachment> emailtAttachments=null);

    }
}
