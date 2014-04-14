namespace KeepFit.Core.Models
{
    public class ProgressPhoto : AuditableEntity
    {
        public override int Id
        {
            get { return ProgressPhotoId; }
        }

        public int ProgressPhotoId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Photo { get; set; }
    }
}
