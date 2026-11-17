using System;
using System.Collections.Generic;
using System.Linq;
using FlatHotel.Models;

namespace FlatHotel.Services
{
    public class BookingService
    {
        private readonly List<Room> _rooms = new List<Room>();
        private readonly List<Reservation> _reservations = new List<Reservation>();
        private int _nextId = 1;

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public Room FindAvailable(string kind)
        {
            return _rooms.FirstOrDefault(r => r.Kind == kind && !r.Booked);
        }

        public Reservation Book(Guest guest, string kind, int nights)
        {
            if (!guest.HasValidEmail())
            {
                throw new ArgumentException("A valid email is required");
            }

            Room room = FindAvailable(kind);
            if (room == null)
            {
                return null;
            }

            room.Booked = true;
            var reservation = new Reservation { Id = _nextId++, Room = room, Guest = guest, Nights = nights };
            _reservations.Add(reservation);
            return reservation;
        }

        public bool Cancel(int reservationId)
        {
            Reservation found = _reservations.FirstOrDefault(r => r.Id == reservationId);
            if (found == null)
            {
                return false;
            }

            found.Room.Booked = false;
            _reservations.Remove(found);
            return true;
        }

        public decimal Revenue()
        {
            return _reservations.Sum(r => r.Total());
        }
    }
}
