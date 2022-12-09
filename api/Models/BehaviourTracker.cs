using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    /// <summary>
    /// Behavior Tracker Class to classify and store behaviour data
    /// </summary>
    public class BehaviourTracker
    {
        public BehaviourTracker(){

        }

        [Key]
        [Required]
        public string EmailAdd { get; set; }

        public int Agression { get; set; }

        public int Agitation { get; set; }

        public int Apathy { get; set; }

        public int EatingProblems { get; set; }

        public int ExcessiveCollecting { get; set; }

        public int ExcessiveOrganizing { get; set; }

        public int ImaginingThings { get; set; }

        public int Impulsiveness { get; set; }

        public int Incontinence { get; set; }

        public int Repetition { get; set; }

        public int ResistancetoCare { get; set; }

        public int Restlessness { get; set; }

        public int SafetyConcerns { get; set; }

        public int Sleeping { get; set; }

        public int Suspicion { get; set; }

        public int Wandering { get; set; }
    }
}
