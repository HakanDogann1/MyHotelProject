using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        public void TBookingStatusApproved(Booking booking);
        public void TBookingStatusApproved2(int id);
        public int TGetBookingCount();
    }
}
