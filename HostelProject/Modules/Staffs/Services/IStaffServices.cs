using vedaproject.Model;

namespace vedaproject.Services
{
    public interface IStaffServices
    {
        object? HostelLookup(Guid id);
        object? IdProofLookup(Guid id);
        object Staffdata();
        object? Staffdisable(Guid id);
        object? Staffid(Guid staffid);
        object? StaffInsert(StaffModel model);
        object? StaffUpdate(StaffModel mo);
    }
}
