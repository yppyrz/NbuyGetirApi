using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Sessions
{
    /// <summary>
    /// Kullanıcıya ait sepet bilgileri, sipariş işlemleri sırasında sessionda saklanacak, Bunun gibi oturum bazlı veri saklama durumlarımız için bu servisi kullanacağız.
    /// </summary>
    public interface ISessionService<TObject> where TObject:class
    {
        void Add(TObject @object, string key); // key value cinsinden ramde oturum bilgsini object olarak tutmak için kullanacağız.
        void Remove(string key); // ilgili session bilgisini ramden kaldırmak için kullanıcaz

        /// <summary>
        /// Ram'de oturum bazlı saklanan değer.
        /// </summary>
        TObject GetSession(string key);
    }
}
