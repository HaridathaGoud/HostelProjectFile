namespace HostelProject.Modules.Maintenance.MaintenanceModel
{
    public class MaintanModel
    {
        public DateTime? Date { get; set; }
        public string? MaintenanceType { get; set; }
        public string? Remarks { get; set; }
        public string? Amount { get; set; }
        public string? Staff { get; set; }
        public string? Document { get; set; }
        //public bool status { get; set; }
        public ICollection<MaintnDocumentModel>? documentModels { get; set; }
    }
}
