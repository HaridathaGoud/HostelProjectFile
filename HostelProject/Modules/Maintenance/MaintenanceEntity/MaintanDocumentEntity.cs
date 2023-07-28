namespace HostelProject.Modules.Maintenance.MaintenanceEntity
{
    public class MaintanDocumentEntity
    {
        public Guid Id { get; set; }
        public Guid MaintenanceId { get; set; }
        public string? Document { get; set; }
        public virtual MaintanEntity? MaintanEntity { get; set; }
    }
}
