using System;

namespace HotelProject.WebUI.Models.Contact
{
    public class AddContactViewModel
    {
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMesaj { get; set; }
        public DateTime ContactDate { get; set; }
    }
}
