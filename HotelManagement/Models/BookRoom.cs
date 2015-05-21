using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class BookRoom
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public Nullable<float> Cost { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<System.DateTime> OutDate { get; set; }
        public int CustomerCount { get; set; }
        public int HotelId { get; set; }
        public Nullable<int> RoomId { get; set; }

        
        public int RoomNumber { get; set; }
        public Nullable<int> floorNo { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string Type { get; set; }
        public Nullable<int> Bedsize { get; set; }
        public string NonSmoking { get; set; }
        public Nullable<int> BedCount { get; set; }
    }
}