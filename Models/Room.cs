using System;

namespace FlatHotel.Models
{
    public class Room
    {
        public int Number { get; set; }
        public string Kind { get; set; }
        public decimal NightlyRate { get; set; }
        public bool Booked { get; set; }

        public Room(int number, string kind, decimal nightlyRate)
        {
            Number = number;
            Kind = kind;
            NightlyRate = nightlyRate;
            Booked = false;
        }

        public string Describe()
        {
            return $"Room {Number} ({Kind}) at {NightlyRate:0.00} per night";
        }
    }

    public class Guest
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Guest(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public bool HasValidEmail()
        {
            return !string.IsNullOrWhiteSpace(Email) && Email.Contains("@");
        }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public Room Room { get; set; }
        public Guest Guest { get; set; }
        public int Nights { get; set; }

        public decimal Total()
        {
            return Room.NightlyRate * Nights;
        }
    }
}
