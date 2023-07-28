using HostelProject.Modules.Avalibility.Entity;
using System.ComponentModel.DataAnnotations;
using vedaproject.vedaproject.Entity;
using HostelStaffEntity = HostelProject.Modules.Avalibility.Entity.HostelStaffEntity;

namespace Veda_Project_Sample.Entity
{
    public class FacilityEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string Facility { get; set; }

        public ICollection<HostelStaffEntity> hostelstaffentity { get; set; }
        public virtual HostelRoomFacilityEntity hostelroomfacilityentity { get; set; }
        //public virtual FacilityEntity facilityentity { get; set; }
    }
}
