using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{
    public class Vehicle
    {
        public string RegistrationNo { get; }
        public string Colour { get; }
        public VehicleType Type { get; }

        public Vehicle(string regNo, string colour, VehicleType type)
        {
            RegistrationNo = regNo;
            Colour = colour;
            Type = type;
        }
    }
}
