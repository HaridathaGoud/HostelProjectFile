using HostelProject.modules.FeeDetails.FeeModel;

namespace HostelProject.Modules.FeeDetails.FeeService
{
    public interface FeeDIservice
    {
        object? getHostelName(Guid Id);
        object? GetId(Guid Id);
        object? GetRoomNo(Guid id);
        object? Gets();
        object? Posts(FeeModels feeModel);
        
    }
}
