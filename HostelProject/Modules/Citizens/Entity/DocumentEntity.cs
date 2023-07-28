using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Modules.Entity
{
    public class DocumentEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CitizenId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual CitizenEntity Tenate { get; set; }
    }
}
