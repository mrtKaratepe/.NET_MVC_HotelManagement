//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nullable<System.DateTime> BDate { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int BookingBookingId { get; set; }
    
        public virtual Booking Booking { get; set; }
    }
}
