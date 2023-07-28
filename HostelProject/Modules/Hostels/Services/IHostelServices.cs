using HostelProject.Modules.Hostels.Models;

namespace HostelProject.Modules.Hostels.Services
{
    public interface IHostelServices
    {
        string? DisableHostelDetails(Guid id);
        public HostelsModel GetHostelById(Guid id);
        public object? GetHostels(Guid staffid);
        public object? PostHostelsDetails(HostelsModel mo);
        object? RoomDisable(Guid id);
        public object? UpdateHostelDetails(HostelsModel model);
    }
}
