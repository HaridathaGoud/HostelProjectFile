using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Maintenance.MaintenanceEntity
{
    public class MaintanEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HostelId { get; set; }
        public DateTime? Date { get; set; }
        public string? MaintenanceType { get; set; }
        public string? Remarks { get; set; }
        public string? Amount { get; set; }
        public Guid? StaffId { get; set; }
        public string? Staff { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Document { get; set; }
       // public bool status { get; set; }
        public List<MaintanDocumentEntity>? DocumentEntities { get; set; }
    }
}
