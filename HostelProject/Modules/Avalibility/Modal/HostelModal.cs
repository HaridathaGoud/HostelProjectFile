namespace Veda_Project_Sample.Modal
{
    public class HostelModal
    {
        public Guid? Id { get; set; }
        public Guid? StaffId { get; set; }
        public string HostelName { get; set; }
        public bool? Status { get; set; }
        public List<RoomsModal> roomsmodal { get; set; }
    }

    public class LookupModal
    {
        public Guid Id { get; set; }
        public string HostelName { get; set; }
        public Guid StaffId { get; set; }
    }
}
