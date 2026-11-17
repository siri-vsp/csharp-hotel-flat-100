using System;
using FlatHotel.Models;
using FlatHotel.Services;

namespace FlatHotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new BookingService();
            service.AddRoom(new Room(101, "single", 80m));
            service.AddRoom(new Room(102, "double", 120m));
            service.AddRoom(new Room(201, "suite", 250m));

            var guest = new Guest("Asha Rao", "asha@example.com");
            Reservation booking = service.Book(guest, "double", 3);

            if (booking == null)
            {
                Console.WriteLine("No room available");
                return;
            }

            Console.WriteLine(booking.Room.Describe());
            Console.WriteLine($"Total for {booking.Nights} nights: {booking.Total():0.00}");
            Console.WriteLine($"Revenue so far: {service.Revenue():0.00}");
        }
    }
}
