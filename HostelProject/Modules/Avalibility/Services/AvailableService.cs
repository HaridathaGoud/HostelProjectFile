using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veda_Project_Sample.Context;
using Veda_Project_Sample.Entity;
using Veda_Project_Sample.Modal;

namespace Veda_Project_Sample.Services
{
    public class AvailableService : IAvailableService
    {
        private readonly AvailibilityContext _availibilityContext;
        public AvailableService(AvailibilityContext availibilityContext)
        {
            _availibilityContext = availibilityContext;
        }

        public object? AllAvailibilityData()
        {
            var data = (from staff in _availibilityContext.hostelStaffEntities.AsQueryable()
                        join hostel in _availibilityContext.hostelEntities.AsQueryable()
                        on staff.HstId equals hostel.Id
                        select new HostelModal()
                        {
                            Id = hostel.Id,
                            StaffId = staff.StaffId,
                            HostelName = hostel.HostelName,
                            Status = hostel.Status,

                            roomsmodal = (from rooms in _availibilityContext.roomsEntities.AsQueryable()
                                          where rooms.HostelId == hostel.Id
                                          select new RoomsModal
                                          {
                                              Id = rooms.Id,
                                              HostelId = rooms.Id,
                                              RoomNumber = rooms.RoomNumber,
                                              AvailabilityBedsCount = rooms.AvailabilityBedsCount,
                                              Fee = rooms.Fee,
                                              ModifiedBy = rooms.ModifiedBy,
                                              ModifiedDate = rooms.ModifiedDate,
                                              CreatedBy = rooms.CreatedBy,
                                              CreatedDate = rooms.CreatedDate,
                                              Status = rooms.Status,

                                              facilityModals = (from hostelroomficility in _availibilityContext.hostelRoomFacilityEntities.AsQueryable()
                                                                join facility in _availibilityContext.facilityEntities.AsQueryable()
                                                                on hostelroomficility.FacilityId equals facility.Id
                                                                where hostelroomficility.RoomId == rooms.Id
                                                                select new FacilityModal()
                                                                {
                                                                    Id = hostelroomficility.Id,
                                                                    RoomId = hostelroomficility.RoomId,
                                                                    Facility = facility.Facility,
                                                                }).ToList(),
                                          }
                                        ).ToList(),

                        }).ToList();

            return data;
        }

        public List<HostelModal> GetAvailibilityAllData(Guid id)
        {
            var data = (from staff in _availibilityContext.hostelStaffEntities.AsQueryable()
                        join hostel in _availibilityContext.hostelEntities.AsQueryable()
                        on staff.HstId equals hostel.Id
                        where staff.StaffId == id
                        select new HostelModal()
                        {
                            Id = hostel.Id,
                            StaffId = staff.StaffId,
                            HostelName = hostel.HostelName,
                            Status = hostel.Status,

                            roomsmodal = (from rooms in _availibilityContext.roomsEntities.AsQueryable()
                                          where rooms.HostelId == hostel.Id
                                          select new RoomsModal
                                          {
                                              Id = rooms.Id,
                                              HostelId = rooms.Id,
                                              RoomNumber = rooms.RoomNumber,
                                              AvailabilityBedsCount = rooms.AvailabilityBedsCount,
                                              Fee = rooms.Fee,
                                              ModifiedBy = rooms.ModifiedBy,
                                              ModifiedDate = rooms.ModifiedDate,
                                              CreatedBy = rooms.CreatedBy,
                                              CreatedDate = rooms.CreatedDate,
                                              Status = rooms.Status,

                                              facilityModals = (from hostelroomficility in _availibilityContext.hostelRoomFacilityEntities.AsQueryable()
                                                                join facility in _availibilityContext.facilityEntities.AsQueryable()
                                                                on hostelroomficility.FacilityId equals facility.Id
                                                                where hostelroomficility.RoomId == rooms.Id
                                                                select new FacilityModal()
                                                                {
                                                                    Id = hostelroomficility.Id,
                                                                    RoomId = hostelroomficility.RoomId,
                                                                    Facility = facility.Facility,
                                                                }).ToList(),
                                          }
                                        ).ToList(),

                        }).ToList();

            return data;
        }

        public object? GetLoopupData(Guid id)
        {
            var data = (from s in _availibilityContext.hostelEntities
                        join v in _availibilityContext.hostelStaffEntities.AsQueryable()
                        on s.Id equals v.HstId
                        where v.StaffId == id
                        select new LookupModal()
                        {
                            Id = s.Id,
                            StaffId = v.StaffId,
                            HostelName = s.HostelName,

                        }).ToList();
            return data;
        }
    }

}  
                    


        

    

