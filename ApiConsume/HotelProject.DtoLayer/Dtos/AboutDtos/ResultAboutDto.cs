﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.AboutDtos
{
    public class ResultAboutDto
    {
        public string AboutTitle1 { get; set; }
        public string AboutTitle2 { get; set; }
        public string AboutContent { get; set; }
        public int StaffCount { get; set; }
        public int RoomCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
