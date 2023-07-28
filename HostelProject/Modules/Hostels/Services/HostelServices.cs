using HostelProject.Modules.Hostels.Context;
using HostelProject.Modules.Hostels.Entity;
using HostelProject.Modules.Hostels.Models;
using Microsoft.EntityFrameworkCore;
using HstlModel = HostelProject.Modules.Hostels.Models.HstlModel;

namespace HostelProject.Modules.Hostels.Services
{
    public class HostelServices : IHostelServices
    {
        private readonly HostelsContex _hostelsContex;
        public HostelServices(HostelsContex hostelsContex)
        {
            _hostelsContex = hostelsContex;
        }


        public HostelsModel GetHostelById(Guid id)
        {
            try
            {
                var data = (from s in _hostelsContex.HostelEntities.Include(x => x.Rooms).Where(x => x.Id == id)
                            select new HostelsModel()
                            {
                                Id = s.Id,
                                HostelName = s.HostelName,
                                Email = s.Email,
                                ContactNumber = s.ContactNumber,
                                Location = s.Location,
                                Address = s.Address,
                                Avatar = s.Avatar,
                                HostelRegNumber = s.HostelRegNumber,
                                ModifiedBy = s.ModifiedBy,
                                ModifiedDate = s.ModifiedDate,
                                CreatedBy = s.CreatedBy,
                                CreatedDate = s.CreatedDate,
                                Status = s.status,
                                RoomsModels = (from s1 in s.Rooms
                                              .Where(x => x.HostelId == s.Id)
                                               select new RoomsModel()
                                               {
                                                   Id = s1.Id,
                                                   HostelId = s1.HostelId,
                                                   RoomNumber = s1.RoomNumber,
                                                   Floor = s1.Floor,
                                                   BedsCount = s1.BedsCount,
                                                   AvailabilityBedsCount = s1.AvailabilityBedsCount,
                                                   Fee = s1.Fee,
                                                   ModifiedBy = s1.ModifiedBy,
                                                   ModifiedDate = s1.ModifiedDate,
                                                   CreatedBy = s1.CreatedBy,
                                                   CreatedDate = s1.CreatedDate,
                                                   status = s1.status,
                                                   FacilitiesModel = (from s2 in _hostelsContex.FacilityEntities 
                                                                      join s3 in _hostelsContex.hostelRoomFacilities on s2.Id equals s3.FacilityId
                                                                      where s1.Id==s3.RoomId
                                                                      select new FacilitiesModel()
                                                                      {
                                                                          Id = s2.Id,
                                                                          Facility = s2.Facility,
                                                                      }).ToList(),
                                               }).ToList(),

                            }).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public object? GetHostels(Guid staffid)
        {
            try
            {
                
                var data=(from staff in _hostelsContex.hostelStaff.Where(x => x.StaffId == staffid)
                        join
                        h in _hostelsContex.HostelEntities
                        on staff.HstId equals h.Id
                        where staff.StaffId == staffid
                         join
                         r in _hostelsContex.RoomsEntities
                         on h.Id equals r.HostelId
                         join
                         f in _hostelsContex.hostelRoomFacilities
                         on r.Id equals f.RoomId
                         select new HstlModel()
                         {
                            Id = h.Id,
                            HostelName = h.HostelName,
                            Location = h.Location,
                            Address = h.Address,
                            Rooms = _hostelsContex.RoomsEntities.Where(x => x.HostelId == h.Id).Count(),
                            AvailabilityBedsCount = _hostelsContex.RoomsEntities.Where(x => x.HostelId == h.Id).Sum(b => b.AvailabilityBedsCount),
                            facilities = (from fac in _hostelsContex.FacilityEntities.Where(a => a.Id == f.FacilityId)
                                          select new FacilityVM()
                                          {
                                              Facility = fac.Facility,
                                          }).Distinct().ToList(),


                         }).FirstOrDefault();
                return data;
         

            //    var data = (from h in _hostelsContex.hostelStaff
            //                join s in _hostelsContex.HostelEntities on h.HstId equals s.Id
            //                where h.StaffId == staffid
            //                select new HostelsModel()
            //                {
            //                    Id = s.Id,
            //                    HostelName = s.HostelName,
            //                    Email = s.Email,
            //                    ContactNumber = s.ContactNumber,
            //                    Location = s.Location,
            //                    Address = s.Address,
            //                    Avatar = s.Avatar,
            //                    HostelRegNumber = s.HostelRegNumber,
            //                    ModifiedBy = s.ModifiedBy,
            //                    ModifiedDate = s.ModifiedDate,
            //                    CreatedBy = s.CreatedBy,
            //                    CreatedDate = s.CreatedDate,
            //                    Status = s.status,
            //                    RoomsModels = (from s1 in _hostelsContex.RoomsEntities
            //                                  .Where(x => x.HostelId == s.Id)
            //                                   select new RoomsModel()
            //                                   {
            //                                       Id = s1.Id,
            //                                       HostelId = s1.HostelId,
            //                                       RoomNumber = s1.RoomNumber,
            //                                       Floor = s1.Floor,
            //                                       BedsCount = s1.BedsCount,
            //                                       AvailabilityBedsCount = s1.AvailabilityBedsCount,
            //                                       Fee = s1.Fee,
            //                                       ModifiedBy = s1.ModifiedBy,
            //                                       ModifiedDate = s1.ModifiedDate,
            //                                       CreatedBy = s1.CreatedBy,
            //                                       CreatedDate = s1.CreatedDate,
            //                                       status = s1.status,
            //                                       FacilitiesModel = (from s2 in _hostelsContex.FacilityEntities
            //                                                          join s3 in _hostelsContex.hostelRoomFacilities on                                          s2.Id equals s3.FacilityId
            //                                                          where s1.Id == s3.RoomId
            //                                                          select new FacilitiesModel()
            //                                                          {
            //                                                              Id = s2.Id,
            //                                                              Facility = s2.Facility,
            //                                                              IsChecked = s2.IsChecked,
            //                                                              RecordStatus = s2.RecordStatus
            //                                                          }).ToList(),
            //                                   }).ToList(),
            //                }).ToList();







                
            //return data;
            }
                       
            catch (Exception ex)
            {
                throw;
            }

        }

        object IHostelServices.PostHostelsDetails(HostelsModel mo)
        {
            try
            {
                HostelEntity hstlen = new HostelEntity();
                hstlen.Id = Guid.NewGuid();
                hstlen.HostelName = mo.HostelName;
                hstlen.Email = mo.Email;
                hstlen.ContactNumber = mo.ContactNumber;
                hstlen.Location = mo.Location;
                hstlen.Address = mo.Address;
                hstlen.Avatar = mo.Avatar;
                hstlen.HostelRegNumber = mo.HostelRegNumber;
                hstlen.ModifiedBy = mo.ModifiedBy;
                hstlen.ModifiedDate = mo.ModifiedDate;
                hstlen.CreatedBy = mo.CreatedBy;
                hstlen.CreatedDate = mo.CreatedDate;
                hstlen.status = mo.Status;
                _hostelsContex.Add(hstlen);
                foreach (var item in mo.RoomsModels)
                {
                    RoomsEntity roomen = new RoomsEntity();
                    roomen.Id = Guid.NewGuid(); ;
                    roomen.HostelId = hstlen.Id;
                    roomen.RoomNumber = item.RoomNumber;
                    roomen.Floor = item.Floor;
                    roomen.BedsCount = item.BedsCount;
                    roomen.AvailabilityBedsCount = item.AvailabilityBedsCount;
                    roomen.Fee = item.Fee;
                    roomen.ModifiedBy = item.ModifiedBy;
                    roomen.ModifiedDate = item.ModifiedDate;
                    roomen.CreatedBy = item.CreatedBy;
                    roomen.CreatedDate = item.CreatedDate;
                    roomen.status = item.status;
                    _hostelsContex.Add(roomen);

                    foreach (var item1 in item.FacilitiesModel)
                    {
                        FacilitiesEntity facien = new FacilitiesEntity();
                        facien.Id = Guid.NewGuid(); 
                        facien.Facility = item1.Facility;
                        var facility=_hostelsContex.FacilityEntities.Where(x=>x.Facility==facien.Facility).Any();
                        if (!facility)
                        {
                            _hostelsContex.Add(facien);
                        }
                        else
                        {
                            throw new Exception("facility already exist");
                        }
                       

                        foreach (var item2 in item.HstlFacilitymodel)
                        {
                            HostelRoomFacilityEntity HstlFaci = new HostelRoomFacilityEntity();
                            HstlFaci.Id = Guid.NewGuid();
                            HstlFaci.RoomId = roomen.Id;
                            HstlFaci.FacilityId = facien.Id;
                            _hostelsContex.Add(HstlFaci);
                        }

                    }
                  
                    
                    _hostelsContex.SaveChanges();
                }
                return mo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        object? IHostelServices.UpdateHostelDetails(HostelsModel model)
        {
            try
            {
                var data = _hostelsContex.HostelEntities.Where(x => x.Id == model.Id).Any();
                if (data)
                {
                    var hostel=_hostelsContex.HostelEntities.Where(x=>x.Id == model.Id).FirstOrDefault();
                    hostel.HostelName = model.HostelName;
                    hostel.Email = model.Email;
                    hostel.Location= model.Location;
                    hostel.Address = model.Address;
                    hostel.Avatar = model.Avatar;
                    hostel.ContactNumber = model.ContactNumber;
                    hostel.ModifiedBy = model.ModifiedBy;
                    hostel.ModifiedDate = model.ModifiedDate;
                    _hostelsContex.Update(hostel);
                    foreach(var item in model.RoomsModels)
                    {
                        var room=_hostelsContex.RoomsEntities.Where(x=>x.HostelId==model.Id).FirstOrDefault();
                        room.RoomNumber = item.RoomNumber;
                        room.Floor=item.Floor;
                        room.BedsCount=item.BedsCount;
                        room.AvailabilityBedsCount=item.AvailabilityBedsCount;
                        room.Fee=item.Fee;
                        room.ModifiedBy=item.ModifiedBy;
                        room.ModifiedDate=item.ModifiedDate;
                        room.status = item.status;
                        _hostelsContex.Update(room);
                        foreach(var item1 in item.FacilitiesModel)
                        {
                            var facility=_hostelsContex.FacilityEntities.FirstOrDefault();
                            facility.Facility=item1.Facility;
                            var facilityupdate = _hostelsContex.FacilityEntities.Where(x => x.Facility == facility.Facility).Any();
                            if (facilityupdate)
                            {
                                _hostelsContex.Update(facility);
                            }
                            else
                            {
                                throw new Exception("facility is not exist");
                            }
                        }
                    }
                    _hostelsContex.SaveChanges();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public string? DisableHostelDetails(Guid id)
        {
            try
            {
                var data = _hostelsContex.HostelEntities.Where(x => x.Id == id).Any();
                if (data) 
                {
                    var data1 = _hostelsContex.HostelEntities.FirstOrDefault(x => x.Id == id);
                    data1.status = false;
                    _hostelsContex.Update(data1);
                    _hostelsContex.SaveChanges();
                }
                else
                {
                    return "invalid Id";
                }
                return "Hosteldisable successfully";
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public object? RoomDisable(Guid id)
        {
            try
            {
                var data = _hostelsContex.RoomsEntities.Where(x => x.Id == id).Any();
                if (data)
                {
                    var data1 = _hostelsContex.RoomsEntities.FirstOrDefault(x => x.Id == id);
                    data1.status = false;
                    _hostelsContex.Update(data1);
                    _hostelsContex.SaveChanges();
                }
                else
                {
                    return "invalid Id";
                }
                return "Roomdisable successfully";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
