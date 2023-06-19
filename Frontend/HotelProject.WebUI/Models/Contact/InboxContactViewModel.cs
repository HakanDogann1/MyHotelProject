using System;

namespace HotelProject.WebUI.Models.Contact
{
    public class InboxContactViewModel
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMesaj { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
