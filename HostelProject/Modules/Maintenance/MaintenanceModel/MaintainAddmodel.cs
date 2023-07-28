using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Maintenance.MaintenanceModel
{
    public class MaintainAddmodel
    {
        [Required]
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
        public List<MaintnDocumentModel> documentModels { get; set; }
    }
}
