using HostelProject.Modules.Citizens.Models;
using HostelProject.Modules.Hostels.Entity;
using HostelProject.Modules.Maintenance.MaintananceContext;
using HostelProject.Modules.Maintenance.MaintenanceEntity;
using HostelProject.Modules.Maintenance.MaintenanceModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectApi.Modules.Context;
using System.Reflection.Metadata;

namespace HostelProject.Modules.Maintenance.MaintenanceServices
{
    public class MaintanServices : MaintanIservices
    {
        private readonly MaintanContext _maintanContext;
        public MaintanServices(MaintanContext maintanContext)
        {
            _maintanContext = maintanContext;
        }

        // Hostel LoockUp
        public object? HostelLockUp(Guid id)
        {
            try
            {
                var data = (from h in _maintanContext.hostelStaffEntities
                            join s in _maintanContext.hostelEntities.AsQueryable()

                                on h.HstId equals s.Id
                            where h.StaffId == id
                            select new HostelLookUp()
                            {
                                Id = h.Id,
                                Satffid = h.StaffId,
                                HostelName = s.HostelName
                            }).ToList();
                return data;
            }
            catch (Exception)
            {
                throw new Exception("");
            }
        }

        // Getting All Data
        public object? GetMaintanaceData()
        {
            var data = (from t1 in _maintanContext.maintans
                        select new MaintanModel()
                        {
                            Date = t1.Date,
                            MaintenanceType = t1.MaintenanceType,
                            Remarks = t1.Remarks,
                            Amount = t1.Amount,
                            Staff = t1.Staff,
                            Document = t1.Document,
                        }).ToList();
            return data;
        }


        // Joining Maintenance table and Document Table and Getting Data
        public object? MaintenaceDocumentData()
        {
            var data = (from t1 in _maintanContext.maintans.Include(x => x.DocumentEntities)
                        select new MaintanModel()
                        {
                            Date = t1.Date,
                            MaintenanceType = t1.MaintenanceType,
                            Remarks = t1.Remarks,
                            Amount = t1.Amount,
                            Staff = t1.Staff,
                            Document = t1.Document,

                            documentModels = (from t2 in _maintanContext.documents
                                              select new MaintnDocumentModel()
                                              {
                                                  Id = t2.Id,
                                                  MaintenanceId = t2.MaintenanceId,
                                                  Document = t2.Document,
                                              }).ToList()

                        }).ToList();

            return data;
        }

        // Add New Record
        public object? MaintenanceAdd(MaintainAddmodel addmodel)
        {
          
                        MaintanEntity entity = new MaintanEntity();
                        entity.Id = Guid.NewGuid();
                        entity.HostelId = addmodel.HostelId;
                        entity.Date = addmodel.Date;
                        entity.MaintenanceType = addmodel.MaintenanceType;
                        entity.Remarks = addmodel.Remarks;
                        entity.Amount = addmodel.Amount;
                        entity.StaffId = addmodel.StaffId;
                        entity.Staff = addmodel.Staff;
                        entity.ModifiedDate = addmodel.ModifiedDate;
                        entity.ModifiedBy = addmodel.ModifiedBy;
                        entity.CreatedDate = addmodel.CreatedDate;
                        entity.CreatedBy = addmodel.CreatedBy;
                        entity.Document = addmodel.Document;
                        _maintanContext.Add(entity);

            foreach (var t in addmodel.documentModels)
            {
                MaintanDocumentEntity document = new MaintanDocumentEntity();
                document.Id = Guid.NewGuid();
                document.MaintenanceId = entity.Id;
                document.Document = t.Document;
                _maintanContext.Add(document);
            }

            
            _maintanContext.SaveChanges();
            return addmodel;        
            
        }

        // Update Record
        public object? UpdateMaintanceRecord(MaintainAddmodel addmodel)
        {
            var data = _maintanContext.maintans.Where(x => x.Id == addmodel.Id).FirstOrDefault();
            data.MaintenanceType = addmodel.MaintenanceType;
            data.Amount  = addmodel.Amount;
            _maintanContext.Update(data);

            foreach(var item in addmodel.documentModels)
            {
             var data1 = _maintanContext.documents.Where(x=>x.MaintenanceId==data.Id).FirstOrDefault();
                data1.Document = item.Document;
                _maintanContext.Update(data1);
                _maintanContext.SaveChanges();
            }
            _maintanContext.SaveChanges();
            return addmodel;
        }

        





        // -------------------------------------------------------
        // Desable Record
        //public string? MaintanDisable(Guid id)
        //{
        //    try
        //    {
        //        var data = _maintanContext.maintans.Where(x => x.Id == id).Any();
        //        if (data)
        //        {
        //            var data1 = _maintanContext.maintans.FirstOrDefault(x => x.Id == id);
        //            data1.status = false;
        //            _maintanContext.Update(data1);
        //            _maintanContext.SaveChanges();
        //        }
        //        else
        //        {
        //            return "invalid Id";
        //        }
        //        return "maintanace record disable successfully";
        //    }
        //    catch (Exception )
        //    {
        //        throw;
        //    }
        //}
    }
}
