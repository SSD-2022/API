using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    /// <summary>
    /// User info Class will be used to get username/emailaddress from register user database for verification
    /// </summary>
    public class UserInfo:RegisterUser
    {

        public UserInfo() { 
        
            this.EmailAdd = EmailAdd;
            this.Password = Password;
        
        }

    }
}
