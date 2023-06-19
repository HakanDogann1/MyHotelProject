using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal:IGenericDal<Booking>
    {
        void BookingStatusApproved(Booking booking);
        void BookingStatusApproved2(int id);
        int GetBookingCount();
        void BookingStatusApproved3(int id);
        void BookingStatusApproved4(int id);
    }
}
