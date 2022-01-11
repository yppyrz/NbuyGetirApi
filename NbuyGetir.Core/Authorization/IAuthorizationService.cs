using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authorization
{
    /// <summary>
    /// Bu servis ile sistemdeki kullanıcının ilgili kaynağa erişim yetkisi olup olmadığını kontrol edeceğiz.
    /// Claim ve Role bazlı kontrolleri içersinde yapacağız.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Sistemde oturum açan kullanıcının sistemdeki özel kaynaklara yetkisi var mı kontrolünü yapacağız.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool HasRole(string roleName);
        bool HasRoles(params string[] roleNames);
        bool HasClaim(string claim);
        bool HasClaims(params string[] claims); // Claims bilgisi kullanıcıya tanımlanmış olan özellikler(Getir çalışanı-Getir müşterisi-Getir dükkanı- indirim kuponu var mı ? gibi kullanıcıya ait olabilecek özelliklere claim diyeceğiz).
    }
}
