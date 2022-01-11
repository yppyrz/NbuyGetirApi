using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Caching
{
    /// <summary>
    /// Uygulamadaki Kategorileri ve bu kategorilere ait alt kategori bilgisini cacheden, yani ram üzerinden okuyacağız. Böylece her seferinde dbden veri çekmediğimiz için daha hızlı bir sonuç döndüreceğiz. Bu gibi fazla crud operasyonun yapılmadığı sınıflarımız ramden okuyabiliriz. Aynı zamanda sepet gibi işlemler için de tanımlanabilir.
    /// </summary>
    public interface ICacheService<TResult> where TResult:class
    {
        /// <summary>
        /// Aynı sessiondaki gibi string key göre
        /// </summary>
        /// <param name="cacheData"></param>
        void SetCache(string key,TResult cacheData);
        /// <summary>
        /// ilgili ramde cachedek dataya set ederken verdiğimiz keyt üzerinden erişip json formatında deserilize edilmiş veriye ulaşacağız
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TResult GetFromCache(string key);
    }
}
