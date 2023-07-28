using Veda_Project_Sample.Modal;

namespace Veda_Project_Sample.Services
{
    public interface IAvailableService
    {
        object? AllAvailibilityData();
        public List<HostelModal> GetAvailibilityAllData(Guid id);
        object? GetLoopupData(Guid id);
    }
}
