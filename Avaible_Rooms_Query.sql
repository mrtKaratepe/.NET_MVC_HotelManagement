use HotelManagement;

Select *
From Room left outer join Booking on Room.RoomId = Booking.RoomId
and Booking.OutDate <= getdate() and Booking.OutDate <= dateadd (day , 90 ,getdate())