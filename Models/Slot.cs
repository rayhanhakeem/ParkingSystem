using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models
{
    public class Slot
    {
        public int Number { get; }
        public Vehicle? Vehicle { get; private set; }

        public bool IsAvailable => Vehicle == null;

        public Slot(int number) => Number = number;

        public void Park(Vehicle v) => Vehicle = v;
        public void Leave() => Vehicle = null;
    }
}
