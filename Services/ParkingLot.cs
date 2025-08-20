using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Services
{
    public class ParkingLot
    {
        private List<Slot> _slots = new List<Slot>();

        public void Create(int size)
        {
            _slots = new List<Slot>();
            for (int i = 1; i <= size; i++)
                _slots.Add(new Slot(i));
            Console.WriteLine($"Created a parking lot with {size} slots");
        }

        public void Park(Vehicle v)
        {
            var slot = _slots.FirstOrDefault(s => s.IsAvailable);
            if (slot == null)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }
            slot.Park(v);
            Console.WriteLine($"Allocated slot number: {slot.Number}");
        }

        public void Leave(int slotNumber)
        {
            var slot = _slots.FirstOrDefault(s => s.Number == slotNumber);
            if (slot != null && !slot.IsAvailable)
            {
                slot.Leave();
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
        }

        public void Status()
        {
            Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
            foreach (var slot in _slots.Where(s => !s.IsAvailable))
            {
                var v = slot.Vehicle;
                Console.WriteLine($"{slot.Number}\t{v.RegistrationNo}\t{v.Type}\t{v.Colour}");
            }
        }

        // REPORTS
        public void TypeOfVehicles(VehicleType type) =>
            Console.WriteLine(_slots.Count(s => s.Vehicle?.Type == type));

        public void RegistrationNumbersOddPlate()
        {
            var list = _slots.Where(s => s.Vehicle != null &&
                                         GetLastDigit(s.Vehicle.RegistrationNo) % 2 == 1)
                             .Select(s => s.Vehicle.RegistrationNo);
            Console.WriteLine(string.Join(", ", list));
        }

        public void RegistrationNumbersEvenPlate()
        {
            var list = _slots.Where(s => s.Vehicle != null &&
                                         GetLastDigit(s.Vehicle.RegistrationNo) % 2 == 0)
                             .Select(s => s.Vehicle.RegistrationNo);
            Console.WriteLine(string.Join(", ", list));
        }

        public void RegistrationNumbersForColour(string colour)
        {
            var list = _slots.Where(s => s.Vehicle?.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase) == true)
                             .Select(s => s.Vehicle.RegistrationNo);
            Console.WriteLine(string.Join(", ", list));
        }

        public void SlotNumbersForColour(string colour)
        {
            var list = _slots.Where(s => s.Vehicle?.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase) == true)
                             .Select(s => s.Number);
            Console.WriteLine(string.Join(", ", list));
        }

        public void SlotNumberForRegistration(string regNo)
        {
            var slot = _slots.FirstOrDefault(s => s.Vehicle?.RegistrationNo == regNo);
            if (slot == null) Console.WriteLine("Not found");
            else Console.WriteLine(slot.Number);
        }

        private int GetLastDigit(string regNo)
        {
            var digits = new string(regNo.Where(char.IsDigit).ToArray());
            return int.TryParse(digits, out int num) ? num % 10 : -1;
        }
    }
}
