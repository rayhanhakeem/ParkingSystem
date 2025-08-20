using ParkingSystem.Models;
using ParkingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    public enum VehicleType { Mobil, Motor }

    class Program
    {
        static void Main()
        {
            ParkingLot lot = new ParkingLot();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                var args = input.Split(' ');
                switch (args[0])
                {
                    case "create_parking_lot":
                        lot.Create(int.Parse(args[1]));
                        break;
                    case "park":
                        var regNo = args[1];
                        var colour = args[2];
                        var type = Enum.Parse<VehicleType>(args[3], true);
                        lot.Park(new Vehicle(regNo, colour, type));
                        break;
                    case "leave":
                        lot.Leave(int.Parse(args[1]));
                        break;
                    case "status":
                        lot.Status();
                        break;
                    case "type_of_vehicles":
                        lot.TypeOfVehicles(Enum.Parse<VehicleType>(args[1], true));
                        break;
                    case "registration_numbers_for_vehicles_with_ood_plate":
                        lot.RegistrationNumbersOddPlate();
                        break;
                    case "registration_numbers_for_vehicles_with_event_plate":
                        lot.RegistrationNumbersEvenPlate();
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        lot.RegistrationNumbersForColour(args[1]);
                        break;
                    case "slot_numbers_for_vehicles_with_colour":
                        lot.SlotNumbersForColour(args[1]);
                        break;
                    case "slot_number_for_registration_number":
                        lot.SlotNumberForRegistration(args[1]);
                        break;
                    case "exit":
                        return;
                }
            }
        }
    }
}
