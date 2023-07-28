namespace vedaproject.vedaproject.Entity
{
    public class HostelStaffEntity
    {
        public Guid Id { get; set; }
        public Guid HstId { get; set; }
        public Guid StaffId { get; set; }

        public virtual StaffEntity Staff { get; set; }

    }
}
