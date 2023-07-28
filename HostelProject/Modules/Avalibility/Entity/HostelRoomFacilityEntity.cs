using System.ComponentModel.DataAnnotations;
using Veda_Project_Sample.Entity;

namespace HostelProject.Modules.Avalibility.Entity
{
    public class HostelRoomFacilityEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public Guid FacilityId { get; set; }
        public ICollection<FacilityEntity> facilityEntities { get; set; }
        public virtual RoomsEntity roomsentity { get; set; }
    }
}
