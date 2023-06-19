using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.Contact
{
    public class UpdateContactDto
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMesaj { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
