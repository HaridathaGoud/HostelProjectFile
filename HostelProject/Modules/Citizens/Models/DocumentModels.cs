using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Modules.Models
{
    public class DocumentModels
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CitizenId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
