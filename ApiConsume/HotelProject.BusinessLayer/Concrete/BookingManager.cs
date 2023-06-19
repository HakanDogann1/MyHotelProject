using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TBookingStatusApproved(Booking booking)
        {
            _bookingDal.BookingStatusApproved(booking);
        }

        public void TBookingStatusApproved2(int id)
        {
            _bookingDal.BookingStatusApproved2(id);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public int TGetBookingCount()
        {
            return _bookingDal.GetBookingCount();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
