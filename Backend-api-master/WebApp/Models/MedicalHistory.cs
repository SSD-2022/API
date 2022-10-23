using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{

    /// <summary>
    /// Mediacal History Class to classify and  store medical history of the user
    /// 
    /// </summary>
    public class MedicalHistory
    {
        public MedicalHistory()
        {

            this.Id = Guid.NewGuid();
            this.UpdatedDate = DateTime.Now;
        }
         
        [Key]
        public Guid Id { get; set; }
        public string EmailAdd { get; set; }

        [DefaultValue(false)]
        public bool Depression { get; set; }

        [DefaultValue(false)]
        public bool NeurologicDisorder { get; set; }

        [DefaultValue(false)]
        public bool HeartDisease { get; set; }

        [DefaultValue(false)]
        public bool Stroke { get; set; }

        [DefaultValue(false)] 
        public bool HypertensiveDisorders { get; set; }

        [DefaultValue(false)]
        public bool RespiratoryDisease { get; set; }

        [DefaultValue(false)]
        public bool Hepatie { get; set; }

        [DefaultValue(false)]
        public bool ConnectiveTissue { get; set; }

        [DefaultValue(false)]
        public bool Musculoskeletal { get; set; }

        [DefaultValue(false)]
        public bool EndocrineMetabolic { get; set; }

        [DefaultValue(false)]
        public bool HematopoieticLymahane { get; set; }

        [DefaultValue(false)]
        public bool RenalGenitaurinan { get; set; }

        [DefaultValue(false)]
        public bool Allergies { get; set; }

        [DefaultValue(false)]
        public bool AlcholAbuse { get; set; }

        [DefaultValue(false)]
        public bool DrugAbuse { get; set; }

        [DefaultValue(false)]
        public bool Smoking { get; set; }

        [DefaultValue(false)]
        public bool Cancer { get; set; }

        [DefaultValue(false)]
        public bool Insomnia { get; set; }

        [DefaultValue(false)]
        public bool SleepApnea { get; set; }

        [DefaultValue(false)]
        public bool Gastrointestinal { get; set; }

        [DefaultValue(false)]
        public bool MajorSurgery { get; set; }


        public string OtherInfo { get; set; }


        public DateTimeOffset UpdatedDate { get; set; }


    }
}
