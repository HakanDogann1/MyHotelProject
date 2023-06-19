using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusApproved(Booking booking)
        {
            using var context = new Context();
           var values =  context.Bookings.Where(x=>x.BookingID==booking.BookingID).FirstOrDefault();
            values.Status = "Onaylandı";
            context.SaveChanges();
        }

        public void BookingStatusApproved2(int id)
        {
            using var context = new Context();
            var values = context.Bookings.Where(x=>x.BookingID==id).FirstOrDefault();
            values.Status = "Onaylandı";
            context.Bookings.Update(values);
            context.SaveChanges();
        }

        public void BookingStatusApproved3(int id)
        {
            using var context = new Context();
            var values = context.Bookings.Where(x=>x.BookingID==id).FirstOrDefault();
            values.Status = "İptal Edildi";
            context.Bookings.Update(values);
            context.SaveChanges();
        }

        public void BookingStatusApproved4(int id)
        {
           using var context= new Context();
            var value = context.Bookings.Where(x=> x.BookingID==id).FirstOrDefault();
            value.Status = "Müşteri Aranacak";
            context.Bookings.Update(value);
            context.SaveChanges();
        }

        public int GetBookingCount()
        {
            using var context = new Context();
            return context.Bookings.Count();
        }
    }
}
