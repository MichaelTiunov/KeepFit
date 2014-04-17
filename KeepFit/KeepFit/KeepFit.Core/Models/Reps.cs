namespace KeepFit.Core.Models
{
    public class Reps:AuditableEntity
    {
        public override int Id
        {
            get { return RepsId; }
        }

        public int RepsId { get; set; }

        public int SetId { get; set; }
        public Set Set { get; set; }

        public int RepCount { get; set; }

        public int ExcerciseId { get; set; }

        public Excercise Excercise { get; set; }
    }
}
