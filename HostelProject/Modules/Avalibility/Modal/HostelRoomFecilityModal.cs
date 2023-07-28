using Veda_Project_Sample.Modal;

namespace HostelProject.Modules.Avalibility.Modal
{
    public class HostelRoomFecilityModal
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid FacilityId { get; set; }
        public List<FacilityModal> facilitymodal { get; set; }
    }
}
