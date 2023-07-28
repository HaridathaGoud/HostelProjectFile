

using HostelProject.Modules.Citizens.Models;
using ProjectApi.Modules.Models;

namespace ProjectApi.Modules.Services
{
    public interface ICitizenService
    {
       public object? CitizenDisable(Guid id);
        public  object? GetCitizens(Guid id);       
       public  List<CitizenModel> GetHostles(Guid id);
       public  List<HostelLookUpModel> HostelLookup(Guid id);
       public  List<IdProofLookUpModel> IdProof(Guid id);
        public  object? PostCitizens(CitizenModel model);
        public  List<RoomModelLookUp> RoomsLookUp(Guid id);
        public object? UpDateCitizen(CitizenModel model);
    }
}
