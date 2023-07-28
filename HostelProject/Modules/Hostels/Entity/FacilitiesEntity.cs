using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Hostels.Entity
{
    public class FacilitiesEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Facility { get; set; }
        public string IsChecked { get; set; }
        public string RecordStatus { get; set; }
        public virtual RoomsEntity roomEntity { get; set; }
        public virtual ICollection<HostelRoomFacilityEntity> HostelRoomFacilities { get; set; }
    }
}
