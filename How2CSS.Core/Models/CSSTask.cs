using How2CSS.Core.Enums;
using How2CSS.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace How2CSS.Core.Models
{
    public class CSSTask : IBaseEntity
    {
        public CSSTask()
        {
            Hints = new HashSet<Hint>();
            TaskResults = new HashSet<TaskResult>();
            TaskDistributions = new HashSet<TaskDistribution>();
        }
        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public int IdAnswer { get; set; }
        public int IdMetadata { get; set; }
        public Difficulty TaskDifficulty { get; set; }
        public virtual Question IdQuestionNavigation { get; set; }
        public virtual Answer IdAnswerNavigation { get; set; }
        public virtual Metadata IdMetadataNavigation { get; set; }
        public virtual ICollection<Hint> Hints { get; set; }
        public virtual ICollection<TaskResult> TaskResults { get; set; }
        public virtual ICollection<TaskDistribution> TaskDistributions { get; set; }
    }
}
