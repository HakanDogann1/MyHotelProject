namespace RapipApiProject.Models
{
    public class GetHotelByLocationViewModel
    {

        public Result[] results { get; set; }
        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public string reviewScore { get; set; }
        }
    }
}
