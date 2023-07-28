
using HostelProject.Modules.Citizens.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Modules.Models
{
    public class CitizenModel
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
        public DateTime CreatedDate { get; set; }
        public bool status { get; set; }
       
        public virtual ICollection<DocumentModels> DocumentModel { get; set; }

        //public virtual ICollection<HostelLookUpModel> HostelLookUpModels { get; set; }

        //public virtual ICollection<RoomModelLookUp> RoomModelLookUps { get; set; }

        //public virtual ICollection<IdProofLookUpModel> IdProofLookUpModels { get; set; }

       
    }
}
