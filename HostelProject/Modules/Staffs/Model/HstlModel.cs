using HostelProject.Modules.Hostels.Models;

namespace HostelProject.Modules.Staffs.Model
{
    public class HstlModel
    {
        public Guid Id { get; set; }
        public string HostelName { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public int Rooms { get; set; }
        public int AvailabilityBedsCount { get; set; }
        public List<FacilityVM> facilities { get; set; }
    }
}
