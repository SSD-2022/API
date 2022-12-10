using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    /// <summary>
    /// Medication List Class to calssigy and store all the data
    /// related to medication of each users
    /// </summary>
    public class MedicationList
    {
        /// <summary>
        /// defalut constructor will initialize a unique id and tiem it was created on each run 
        /// </summary>
        public MedicationList(){

            this.Id = Guid.NewGuid();
            this.RegisterDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public string EmailAdd { get; set; }

        [MaxLength(140)]
        public string MedName { get; set; }

        [MaxLength(264)]
        public string MedDescp { get; set; }

        [MaxLength(64)]
        public string Dosage { get; set; }

        public DateTimeOffset RegisterDate { get; set; }
    }
}
