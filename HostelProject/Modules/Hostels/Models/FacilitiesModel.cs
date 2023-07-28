using HostelProject.Modules.Hostels.Entity;
using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Hostels.Models
{
    public class FacilitiesModel
    {

        public Guid Id { get; set; }
        public string Facility { get; set; }
        public string IsChecked { get; set; }
        public string RecordStatus { get; set; }
        //public virtual RoomsModel roommodel { get; set; }
    }
    public class FacilityVM
    {
        public string Facility { get; set; }

    }
}
