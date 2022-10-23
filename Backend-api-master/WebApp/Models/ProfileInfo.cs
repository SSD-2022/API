namespace WebApp.Models
{
    /// <summary>
    /// This classs is used to extract username/email address from register user class
    /// for getting email address for a specific profile
    /// </summary>
    public class ProfileInfo:RegisterUser
    {
        public ProfileInfo()
        {
            this.EmailAdd = EmailAdd;
        }
    }
}
