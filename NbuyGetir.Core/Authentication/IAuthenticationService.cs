using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Authentication
{

    public class AuthenticationError
    {
        public string Code { get; set; } // 202 UserNotFound gibi hata kodları
        public string Message { get; set; } // Böyle bir kullanıcı sistemde bulunamadı.
        public string Key { get; set; } // Username.
    }

    public class AuthenticationResult
    {
        public bool IsSucceded { get; private set; } = true;
        public string AccessToken { get; private set; }
        public List<AuthenticationError> Errors { get; private set; }

        public void AddError(AuthenticationError error)
        {
            IsSucceded = false;
            Errors.Add(error);
        }

        void SetAccessToken(string token)
        {
            if (IsSucceded)
            {
                AccessToken = token;
            }
        }

    }

    public interface IAuthenticationService
    {
        /// <summary>
        /// Login olduktan sonra rememberMe true olursa 1 aylık bir token olsun. False ise 1 günlük token oluşturulacak.
        /// JWT JSon web token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        AuthenticationResult Login(string email, string password, bool rememberMe);

        void LogOut(string accessToken); // Kullanıcıya giriş işlemleri için verilen accessToken expire edeceğiz.Artık bu access token geçersiz hale getirilecek. Kullanıcının sistemden güvenli çıkışı için var.
    }
}
