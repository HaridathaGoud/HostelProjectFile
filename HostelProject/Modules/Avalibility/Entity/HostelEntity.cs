using System.ComponentModel.DataAnnotations;
using vedaproject.vedaproject.Entity;

namespace Veda_Project_Sample.Entity
{
    public class HostelEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string HostelName { get; set; }
        public bool? Status { get; set; }
        public ICollection<RoomsEntity> roomsEntities { get; set; }

        public virtual HostelStaffEntity hostelStaffEntities { get; set; }
    }
}
