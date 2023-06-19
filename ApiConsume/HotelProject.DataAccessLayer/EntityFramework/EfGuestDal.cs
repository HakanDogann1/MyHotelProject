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
    public class EfGuestDal : GenericRepository<Guest>, IGuestDal
    {
        public EfGuestDal(Context context) : base(context)
        {
        }

        public int GetGuestCount()
        {
            using var context = new Context();
            return context.Guests.Count();
        }

        public List<Guest> GetLast6GuestList()
        {
           using var context = new Context();
            return context.Guests.OrderByDescending(x=>x.GuestID).ToList();
        }
    }
}
