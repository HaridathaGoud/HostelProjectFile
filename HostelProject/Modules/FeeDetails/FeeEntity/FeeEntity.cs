using HostelProject.Modules.Hostels.Entity;
using System.ComponentModel.DataAnnotations;
using vedaproject.vedaproject.Entity;

namespace HostelProject.Modules.FeeDetails.FeeEntity
{
    public class FeeEntitys
    {
        [Key]
        public Guid Id { get; set; }
        public string TransactionId { get; set; }
        public Guid HostelId { get; set; }
        public Guid RoomId { get; set; }
        public Guid CitizenId { get; set; }
        public long Fee { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PaymentType { get; set; }
        public string Other { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<HostelEntity> hostelEntities { get; set; }

        public ICollection<HostelStaffEntity> hostelStaffEntities { get; set; }
    }
}
