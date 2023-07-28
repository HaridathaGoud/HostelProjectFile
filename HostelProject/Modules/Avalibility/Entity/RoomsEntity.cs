using HostelProject.Modules.Avalibility.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Veda_Project_Sample.Entity
{
    public class RoomsEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostelId { get; set; }
        public string RoomNumber { get; set; }
        public int AvailabilityBedsCount { get; set; }
        public int Fee { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? Status { get; set; }

        public ICollection<HostelRoomFacilityEntity> hostelRoomFacilityEntities { get; set; }
        public virtual HostelEntity hostelentity { get; set; }
    }
}
