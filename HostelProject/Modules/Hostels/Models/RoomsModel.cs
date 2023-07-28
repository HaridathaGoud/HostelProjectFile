using HostelProject.Modules.Hostels.Entity;
using System.ComponentModel.DataAnnotations;

namespace HostelProject.Modules.Hostels.Models
{
    public class RoomsModel
    {

        public Guid Id { get; set; }

        public Guid HostelId { get; set; }

        public string RoomNumber { get; set; }

        public string Floor { get; set; }

        public int BedsCount { get; set; }

        public int AvailabilityBedsCount { get; set; }

        public int Fee { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public bool status { get; set; }

        //public virtual HostelsModel HstlsModel { get; set; }
        public List<FacilitiesModel> FacilitiesModel { get; set; }
        public List<HostelRoomFacilitityModel> HstlFacilitymodel { get; set; }


    }
}
