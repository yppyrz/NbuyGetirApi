﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Security
{

    interface IDecryptService
    {
        /// <summary>
        /// byte[] olarak şifrelenmiş datayı, byte[] olarak şifresi çözülmüş bir şekilde geriye döndürebiliriz.
        /// </summary>
        /// <param name="chiper"></param>
        /// <returns></returns>
        byte[] Decrypt(byte[] chiper);
    }
}
