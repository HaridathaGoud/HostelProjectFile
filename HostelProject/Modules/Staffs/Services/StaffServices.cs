using HostelProject.Modules.Citizens.Models;
using HostelProject.Modules.Staffs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProjectApi.Modules.Context;
using vedaproject.Model;
using vedaproject.vedaproject.Context;
using vedaproject.vedaproject.Entity;

namespace vedaproject.Services
{
    public class StaffServices : IStaffServices
    {
        private readonly StaffContext _staffContext;

        public StaffServices(StaffContext staffContext)
        {
            _staffContext = staffContext;
        }

        public object? HostelLookup(Guid id)
        {
            try
            {
                var data = (from h in _staffContext.Staffs
                            join s in _staffContext.Hostel.AsQueryable()
                            on h.HstId equals s.Id
                            where h.StaffId == id
                            select new HostelLookupModel()
                            {
                                Id = s.Id,
                                Satffid = h.StaffId,
                                HostelName = s.HostelName
                            }).ToList();

                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? IdProofLookup(Guid id)
        {
            try
            {
                var data = (from hostel in _staffContext.Projects.AsQueryable()
                                //where hostel.Id==id
                            select new IdproofLookupModel() 
                            {
                                StaffId = hostel.Id,
                                Avatar = hostel.IdProof
                            }).ToList();
                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public object Staffdata()
        {
            try
            {
                var data = (from s in _staffContext.Projects.Include(x => x.stafff).Include(x => x.HostelStaff)
                            select new StaffModel()
                            {
                                Id = s.Id,
                                StaffName = s.StaffName,
                                MobileNo = s.MobileNo,
                                Address = s.Address,
                                IdProof = s.IdProof,
                                Salary = s.Salary,
                                Designation = s.Designation,
                                ModifiedDate = s.ModifiedDate,
                                ModifiedBy = s.ModifiedBy,
                                CreatedDate = s.CreatedDate,
                                CreatedBy = s.CreatedBy,
                                Status = s.Status,

                                Hostel = (from s1 in _staffContext.Staffs
                                          select new HostelStaffModel
                                          {
                                              Id = s1.Id,
                                              HstId = s1.HstId,
                                              StaffId = s1.StaffId,
                                              //Documents = (from s2 in _staffContext.docu
                                              //             select new StaffDocumentModel
                                              //             {
                                              //                 Id = s2.Id,
                                              //                 StaffId = s2.StaffId,
                                              //                 Avatar = s2.Avatar,
                                              //             }).ToList(),

                                             }).ToList(),





                            }).ToList();
                return data;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? Staffdisable(Guid id)
        {
            try
            {
                var data = _staffContext.Projects.Where(x => x.Id == id).Any();
                if(data)
                {
                    var da=_staffContext.Projects.FirstOrDefault(x=> x.Id == id);
                    da.Status = false;
                    _staffContext.Update(da);
                    _staffContext.SaveChanges();
                }
              
                else
                {
                    return "id inavalid";
                }
                return data;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public object? Staffid(Guid staffid)
        {
            try
            {
                var data = _staffContext.Projects.Where(x => x.Id == staffid).Any();
                if (data)
                {
                    var data1 = (from s in _staffContext.Projects.Include(x => x.stafff).Include(x => x.HostelStaff)
                                 select new StaffModel()
                                 {
                                     Id = s.Id,

                                     StaffName = s.StaffName,
                                     MobileNo = s.MobileNo,
                                     Address = s.Address,
                                     IdProof = s.IdProof,
                                     Salary = s.Salary,
                                     Designation = s.Designation,
                                     ModifiedDate = s.ModifiedDate,
                                     ModifiedBy = s.ModifiedBy,
                                     CreatedDate = s.CreatedDate,
                                     CreatedBy = s.CreatedBy,
                                     Status = s.Status,

                                     Hostel = (from s1 in _staffContext.Staffs
                                               select new HostelStaffModel
                                               {
                                                   Id = s1.Id,
                                                   HstId = s1.HstId,
                                                   StaffId = s1.StaffId,

                                               }).ToList(),
                                     Documents = (from s2 in _staffContext.docu
                                                  select new StaffDocumentModel()
                                                  {
                                                      Id = s2.Id,
                                                      StaffId = s2.StaffId,
                                                      Avatar = s2.Avatar,

                                                  }).ToList()


                                 }).ToList();
                    return data1;

                }
                else
                {
                    return "id exists";
                }


            }

            catch (Exception)
            {

                throw;
            }
        }

        public object? StaffInsert(StaffModel model)
        {
            try
            {
                var ExistId = _staffContext.Projects.Where(x => x.Id == model.Id).Any();
                if (ExistId)
                {
                    throw new Exception("id already exists");
                }
                StaffEntity entity = new StaffEntity();
                entity.Id = Guid.NewGuid();
                entity.StaffName = model.StaffName;
                entity.MobileNo = model.MobileNo;
                entity.Address = model.Address;
                entity.IdProof = model.IdProof;
                entity.Salary = model.Salary;
                entity.Designation = model.Designation;
                entity.ModifiedDate = model.ModifiedDate;
                entity.ModifiedBy = model.ModifiedBy;
                entity.CreatedDate = model.CreatedDate;
                entity.CreatedBy = model.CreatedBy;
                entity.Status = model.Status;
                _staffContext.Projects.Add(entity);

                if (model.Hostel != null)
                {
                    foreach (var item in model.Hostel)
                    {
                        HostelStaffEntity staf = new HostelStaffEntity();
                        staf.Id = Guid.NewGuid();
                        staf.HstId =item.HstId;
                        staf.StaffId =entity.Id;
                        _staffContext.Add(staf);
                    }
                }
                if (model.Documents != null)
                {
                    foreach (var doc in model.Documents)
                    {
                        StaffDocumentEntity docu = new StaffDocumentEntity();
                        docu.Id = Guid.NewGuid();
                        docu.StaffId = entity.Id;
                        docu.Avatar = doc.Avatar;
                        _staffContext.Add(docu);

                    }

                }
                _staffContext.SaveChanges();
                return model;



            }
            catch (Exception)
            {

                throw;
            }


        }
        public object? StaffUpdate(StaffModel mo)
        {
            try
            {
                var data = _staffContext.Projects.Where(x => x.Id == mo.Id).FirstOrDefault();
                if (data != null)
                {
                    //data.Id = Guid.NewGuid();
                  
                    data.StaffName = mo.StaffName;
                    data.MobileNo = mo.MobileNo;
                    data.Address = mo.Address;
                    data.IdProof = mo.IdProof;
                    data.Salary = mo.Salary;
                    data.Designation = mo.Designation;
                    data.ModifiedDate = mo.ModifiedDate;
                    data.ModifiedBy = mo.ModifiedBy;
                    data.CreatedDate = mo.CreatedDate;
                    data.CreatedBy = mo.CreatedBy;
                    data.Status = mo.Status;
                    _staffContext.Update(data);

                    if (mo.Hostel != null)
                    {
                        foreach (var da in mo.Hostel)
                        {
                            var hststaff = _staffContext.Staffs.Where(x => x.StaffId == da.StaffId).FirstOrDefault();
                            if (hststaff != null)
                            {

                                _staffContext.Update(hststaff);

                            }


                        }

                    }
                    if (mo.Documents != null)
                    {

                        foreach (var d in mo.Documents)
                        {
                            var dstaff = _staffContext.docu.Where(x => x.StaffId == d.StaffId).FirstOrDefault();
                            if (dstaff != null)
                            {
                                dstaff.Avatar = d.Avatar;
                                _staffContext.Update(dstaff);
                            }


                        }
                        _staffContext.SaveChanges();

                    }

                }
                return mo;

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}


       
    


      
    

