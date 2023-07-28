namespace HostelProject.Modules.Hostels.Entity
{
    public class HostelRoomFacilityEntity
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid FacilityId { get; set; }
        public virtual RoomsEntity Rms { get; set; }
        public virtual FacilitiesEntity FacilitiesEntity { get; set; }
    }
}
