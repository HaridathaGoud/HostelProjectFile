using HostelProject.Modules.Hostels.Models;
using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Hostels.Entity
{
    public class RoomsEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostelId { get; set; }
        public string RoomNumber { get; set; }
        public string Floor { get; set; }
        public int BedsCount { get; set; }
        public int AvailabilityBedsCount { get; set; }
        public int Fee { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool status { get; set; }
        public virtual HostelEntity Hostels { get; set; }
        public virtual ICollection<FacilitiesEntity> Facilities { get; set; }
        public virtual ICollection<HostelRoomFacilityEntity> HstlFacility { get; set; }
    }
}
