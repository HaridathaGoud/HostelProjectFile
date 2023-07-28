using Veda_Project_Sample.Entity;

namespace HostelProject.Modules.Avalibility.Entity
{
    public class HostelStaffEntity
    {
        public Guid Id { get; set; }
        public Guid HstId { get; set; }
        public Guid StaffId { get; set; }
        public virtual FacilityEntity facilityentity { get; set; }

        public virtual ICollection<HostelEntity> Hstl { get; set; }
    }
}
