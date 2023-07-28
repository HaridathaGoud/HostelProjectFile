using HostelProject.Modules.Hostels.Entity;

namespace HostelProject.Modules.Hostels.Models
{
    public class HostelRoomFacilitityModel
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid FacilityId { get; set; }
        //public virtual FacilitiesModel FacilitiesModel { get; set; }
    }
}

