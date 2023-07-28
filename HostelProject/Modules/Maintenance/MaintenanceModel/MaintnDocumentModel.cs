using HostelProject.Modules.Maintenance.MaintenanceEntity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HostelProject.Modules.Maintenance.MaintenanceModel
{
    public class MaintnDocumentModel
    {
        public Guid Id { get; set; }
        public Guid MaintenanceId { get; set; }
        public string? Document { get; set; }

       // public virtual MaintanModel? MaintanModel { get; set; }
        //public virtual MaintainAddmodel? Addmodel { get; set; }
    }
}
