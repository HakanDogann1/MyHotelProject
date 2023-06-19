﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDtos
{
    public class RoomAddDto
    {
        [Required(ErrorMessage ="Lütfen bu alanı boş geçmeyiniz.")]
        public string RoomNumber { get; set; }
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat alanını boş geçmeyiniz.")]
        public int Price { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak sayısını boş geçmeyiniz.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısını boş geçmeyiniz.")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
