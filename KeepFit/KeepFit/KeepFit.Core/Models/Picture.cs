namespace KeepFit.Core.Models
{
    public class Picture : AuditableEntity
    {
        public override int Id
        {
            get { return PictureId; }
        }

        public int PictureId { get; set; }

        public int? ProductId { get; set; }

        public int? ExcerciseId { get; set; }

        public Product Product { get; set; }

        public Excercise Excercise { get; set; }

        public string Photo { get; set; }
    }
}
