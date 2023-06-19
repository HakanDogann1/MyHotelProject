using HotelProject.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IGuestDal:IGenericDal<Guest>
    {
        public int GetGuestCount();
        public List<Guest> GetLast6GuestList();
    }
}
