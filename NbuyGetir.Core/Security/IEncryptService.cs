using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Security
{
    public interface IEncryptService
    {
        /// <summary>
        /// MD5,SHA,DES veya 3DES gibi algoritmalar ile şifreleme işlemi yapan bir servis olarak kullanılabilir.
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string Encrypt(string plainText);

    }
}
