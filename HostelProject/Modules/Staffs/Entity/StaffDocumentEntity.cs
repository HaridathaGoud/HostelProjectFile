namespace vedaproject.vedaproject.Entity
{
    public class StaffDocumentEntity
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public string Avatar { get; set; }


        public virtual StaffEntity staffDoc { get; set; }
    }
}
