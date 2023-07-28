using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Hostels.Entity
{
    public class HostelEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string HostelName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string HostelRegNumber { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool status { get; set; }
        public virtual ICollection<RoomsEntity> Rooms { get; set; }
    }
}
