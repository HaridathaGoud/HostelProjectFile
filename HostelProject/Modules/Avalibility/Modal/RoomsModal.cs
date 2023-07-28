namespace Veda_Project_Sample.Modal
{
    public class RoomsModal
    {
        public Guid? Id { get; set; }
        public Guid? HostelId { get; set; }
        public string RoomNumber { get; set; }
        public int? AvailabilityBedsCount { get; set; }
        public int? Fee { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Status { get; set; }

        public List<FacilityModal> facilityModals { get; set; }

    }
}
