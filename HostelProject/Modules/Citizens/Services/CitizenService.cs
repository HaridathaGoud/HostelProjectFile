
using HostelProject.Modules.Citizens.Models;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Modules.Context;
using ProjectApi.Modules.Entity;
using ProjectApi.Modules.Models;
using System.Threading.Tasks.Dataflow;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectApi.Modules.Services
{
    public class CitizenService:ICitizenService
    {
        private readonly CitizenContext _citizenContext;

        public CitizenService(CitizenContext citizenContext)
        {
            _citizenContext = citizenContext;
        }

        public object? CitizenDisable(Guid id)
        {
            try
            {
                var data = _citizenContext.citizenEntities.Where(x => x.Id == id).Any();
                    if (data)
                {
                    var status=_citizenContext.citizenEntities.FirstOrDefault(x => x.Id == id); 
                    if (status != null)
                    {
                        status.status = false;
                        _citizenContext.Update(status);
                        _citizenContext.SaveChanges();
                    }
                    else
                    {
                        return "Id Invalid";
                    }
                    
                }
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? GetCitizens(Guid id)
        {
            try
            {
                var data = (from s in _citizenContext.citizenEntities.AsQueryable().Include(x => x.DocEntity)
                            where s.Id == id
                            select new CitizenModel()
                            {
                                Id = s.Id,
                                HostelId = s.HostelId,
                                RoomId = s.RoomId,
                                CitizenName = s.CitizenName,
                                Email = s.Email,
                                MobileNumber = s.MobileNumber,
                                AlternateNumber = s.AlternateNumber,
                                Address = s.Address,
                                Guardian = s.Guardian,
                                GuardianNumber = s.GuardianNumber,
                                IdProof = s.IdProof,
                                Fee = s.Fee,
                                JoinDate = s.JoinDate,
                                ModifeidBy = s.ModifeidBy,
                                ModifiedDate = s.ModifiedDate,
                                CreatedBy = s.CreatedBy,
                                CreatedDate = s.CreatedDate,
                                status = s.status,

                                DocumentModel = (from d in s.DocEntity
                                                 select new DocumentModels()
                                                 {
                                                     Id = d.Id,
                                                     CitizenId = d.Id,
                                                     ImageUrl = d.ImageUrl
                                                 }).ToList()

                            }).FirstOrDefault();

                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CitizenModel> GetHostles(Guid id)
        {
            try
            {
               
                var  Tenate=(from h in _citizenContext.citizenEntities.AsQueryable()
                             join d in _citizenContext.hostelEntities on h.HostelId equals d.Id
                            join c in _citizenContext.hostelstaff on d.Id equals c.HstId
                            where d.Id == c.HstId
                            select new CitizenModel()
                            {
                                Id = h.Id,
                                HostelId = h.HostelId,
                                RoomId = h.RoomId,
                                CitizenName = h.CitizenName,
                                Email = h.Email,
                                MobileNumber = h.MobileNumber,
                                AlternateNumber = h.AlternateNumber,
                                Address = h.Address,
                                Guardian = h.Guardian,
                                GuardianNumber = h.GuardianNumber,
                                IdProof = h.IdProof,
                                Fee = h.Fee,
                                JoinDate = h.JoinDate,
                                ModifeidBy = h.ModifeidBy,
                                ModifiedDate = h.ModifiedDate,
                                CreatedBy = h.CreatedBy,
                                CreatedDate = h.CreatedDate,
                                status = h.status,

                            }).ToList();

                            
                return Tenate;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<HostelLookUpModel> HostelLookup(Guid id)
        {
           try
            {
                var data = (from h in _citizenContext.hostelstaff
                            join s in _citizenContext.hostelEntities.AsQueryable()
                            on h.HstId equals s.Id where h.StaffId==id 
                            select new HostelLookUpModel()
                            {
                                Id=s.Id,
                                Satffid=h.StaffId,
                                HostelName=s.HostelName
                            }).ToList();

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<IdProofLookUpModel> IdProof(Guid id)
        {
           try
            {
                var data =(from hostel in _citizenContext.citizenEntities.AsQueryable()
                         //where hostel.Id==id
                         select new IdProofLookUpModel()
                         {
                             CitizenId=hostel.Id,
                             Avatar=hostel.IdProof
                         }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? PostCitizens(CitizenModel model)
        {
            try
            {
                var ExistId = _citizenContext.citizenEntities.Where(x => x.Id == model.Id).Any();
                if (ExistId)
                {
                    throw new Exception(" Id Already Exists");
                }
                CitizenEntity obj=new CitizenEntity();
                obj.Id = Guid.NewGuid();
                obj.HostelId = model.HostelId;
                obj.RoomId=model.RoomId;
                obj.CitizenName=model.CitizenName;
                obj.Email= model.Email;
                obj.MobileNumber = model.MobileNumber;
                obj.AlternateNumber=model.AlternateNumber;
                obj.Address= model.Address;
                obj.Guardian=model.Guardian;
                obj.GuardianNumber=model.GuardianNumber;
                obj.IdProof=model.IdProof;
                obj.Fee=model.Fee;
                obj.JoinDate=model.JoinDate;
                obj.ModifeidBy=model.ModifeidBy;
                obj.ModifiedDate=model.ModifiedDate;
                obj.CreatedBy=model.CreatedBy;
                obj.CreatedDate=model.CreatedDate;
                obj.status = model.status;
                _citizenContext.Add(obj);

                if (model.DocumentModel != null)
                {
                    foreach(var item in model.DocumentModel)
                    {
                        DocumentEntity doc = new DocumentEntity();
                        doc.Id = Guid.NewGuid();
                        doc.CitizenId = obj.Id;
                        doc.ImageUrl = item.ImageUrl;
                        _citizenContext.Add(doc);
                    }
                }
                _citizenContext.SaveChanges();
                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<RoomModelLookUp> RoomsLookUp(Guid id)
        {
            try
            {
                var data = (from Rn in _citizenContext.hostelEntities
                            join list in _citizenContext.RoomsEntities.AsQueryable()
                            on Rn.Id equals list.HostelId
                            select new RoomModelLookUp()
                            {
                                Id = Rn.Id,
                                RoomNumber = list.RoomNumber
                            }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? UpDateCitizen(CitizenModel model)
        {
            try
            {
                var data = _citizenContext.citizenEntities.Where(x => x.Id == model.Id).SingleOrDefault();
                if (data != null)
                {
                    data.CitizenName=model.CitizenName;
                    data.Address=model.Address;
                    _citizenContext.Update(data);

                    if(model.DocumentModel != null)
                    {
                        foreach(var item in model.DocumentModel)
                        {
                            var doc=_citizenContext.documentEntities.Where(x=>x.CitizenId== item.CitizenId).SingleOrDefault();
                            if(doc != null)
                            {
                                doc.ImageUrl=item.ImageUrl;
                                _citizenContext.Update(doc);
                            }
                        }
                    }
                    _citizenContext.SaveChanges();
                    

                }
                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
