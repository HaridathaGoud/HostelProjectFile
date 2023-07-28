using HostelProject.Modules.Maintenance.MaintenanceModel;

namespace HostelProject.Modules.Maintenance.MaintenanceServices
{
    public interface MaintanIservices
    {      
        object? GetMaintanaceData();
        object? HostelLockUp(Guid id);
        object? MaintenaceDocumentData();
        object? MaintenanceAdd(MaintainAddmodel addmodel);
        object? UpdateMaintanceRecord(MaintainAddmodel addmodel);
    }
}
