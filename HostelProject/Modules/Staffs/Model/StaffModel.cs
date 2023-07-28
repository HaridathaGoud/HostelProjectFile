using vedaproject.vedaproject.Entity;
namespace vedaproject.Model
{
    public class StaffModel
    {
        public Guid Id { get; set; }
        public Guid HostelId { get; set; }
        public string StaffName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string IdProof { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<HostelStaffModel> Hostel { get; set; }
        public virtual ICollection<StaffDocumentModel> Documents { get; set; }
    }
}
