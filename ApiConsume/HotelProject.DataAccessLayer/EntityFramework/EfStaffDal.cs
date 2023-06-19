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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetLast4StaffList()
        {
            using var context = new Context();
            return context.Staffs.OrderByDescending(x=>x.StaffID).Take(4).ToList();
        }

        public int GetStaffCount()
        {
            using var context = new Context();
            return context.Staffs.Count();
        }
    }
}
