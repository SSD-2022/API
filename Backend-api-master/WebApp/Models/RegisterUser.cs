using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    /// <summary>
    /// Register user class to classify data when user registers
    /// </summary>
    public class RegisterUser
    {
        /// <summary>
        /// Constructor will generate a unique Id for each cx and time that the account was created
        /// </summary>
        public RegisterUser()
        {
            this.Id = Guid.NewGuid();
            this.RegisterDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

       
        public string EmailAdd { get; set; }

        
        
        public string Password { get; set; }

        
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        
        public string Sex { get; set; }


        
        public string PhoneNum { get; set; }

        
        public string Address { get; set; }

        public bool TermCon { get; set; }

        
        public DateTimeOffset RegisterDate { get; set; }

    }
}
