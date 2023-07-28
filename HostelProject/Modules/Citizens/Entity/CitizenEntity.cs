using HostelProject.Modules.Hostels.Entity;
using System.ComponentModel.DataAnnotations;
using vedaproject.vedaproject.Entity;

namespace ProjectApi.Modules.Entity
{
    public class CitizenEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostelId { get; set; }
        public Guid RoomId { get; set; }
        public string? CitizenName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? AlternateNumber { get; set; }
        public string? Address { get; set; }
        public string? Guardian { get; set; }
        public string? GuardianNumber { get; set; }
        public string? IdProof { get; set; }
        public int? Fee { get; set; }
        public DateTime JoinDate { get; set; }
        public string ModifeidBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set;}
        public bool status { get; set; }

        public ICollection<DocumentEntity>? DocEntity { get; set; }
        public ICollection<HostelEntity> Hstl { get;set; }

        public ICollection<HostelStaffEntity> Hts { get;set; }
        
    }
}
