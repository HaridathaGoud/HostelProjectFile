using HostelProject.modules.FeeDetails.FeeModel;
using HostelProject.Modules.FeeDetails.FeeContext;
using HostelProject.Modules.FeeDetails.FeeEntity;
using HostelProject.Modules.FeeDetails.FeeModel;

namespace HostelProject.Modules.FeeDetails.FeeService
{
    public class FeeService :FeeDIservice
    {
        private readonly FeeContexts _feeContexts;
        public FeeService(FeeContexts feeContexts)
        {
            _feeContexts = feeContexts;
        }

        public object? getHostelName(Guid Id)
        {
            try
            {
                var data = (from parant in _feeContexts.hostelStaffEntities
                            join child in _feeContexts.hostelEntities.AsQueryable()
                            on parant.HstId equals child.Id
                            where parant.StaffId == Id
                            select new FeeHostelNameLookUp
                            {
                                Id = parant.Id,
                                Satffid = parant.StaffId,
                                HostelName = child.HostelName,
                            }).ToList();
                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? GetId(Guid Id)
        {
            var data = _feeContexts.feeEntities.Where(x => x.Id == Id).FirstOrDefault();
            return data;
        }

        public object GetRoomNo(Guid id)
        {
            var data = (from parant2 in _feeContexts.hostelEntities
                        join child2 in _feeContexts.roomsEntities
                        on parant2.Id equals child2.HostelId
                        select new RoomNoLookUp
                        {
                            Id = parant2.Id,
                            RoomNumber = child2.RoomNumber
                        }).ToList();
            return data;
        }

        public object? Gets()
        {
            var data=_feeContexts.feeEntities.ToList();
            return data;
        }



        public object? Posts(FeeModels feeModel)
        {
            FeeEntitys feeEntitys = new FeeEntitys();
             feeEntitys.Id = Guid.NewGuid();
            feeEntitys.TransactionId = feeModel.TransactionId;
            feeEntitys.HostelId = feeModel.HostelId;
            feeEntitys.RoomId = feeModel.RoomId;
            feeEntitys.CitizenId = feeModel.CitizenId;
            feeEntitys.Fee = feeModel.Fee;
            feeEntitys.FromDate = feeModel.FromDate;
            feeEntitys.ToDate = feeModel.ToDate;
            feeEntitys.PaymentType = feeModel.PaymentType;
            feeEntitys.Other = feeModel.Other;
            feeEntitys.CreatedBy = feeModel.CreatedBy;
            feeEntitys.CreatedDate = feeModel.CreatedDate;
            _feeContexts.Add(feeEntitys);
            _feeContexts.SaveChanges();
            return feeEntitys;
    }
    }
}
