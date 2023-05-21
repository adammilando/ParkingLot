using ParkingLot.Repository;
using ParkingLot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Service
{
    public class Report
    {
        private Parking _parking;

        public Report(Parking parking)
        {
            _parking = parking;
        }

        public int TotalVehicleByType(VehicleType type)
        {
            return _parking.GetFilledSlot().Count(slot => slot.Vehicle.VehicleType == type);
        }

        public IEnumerable<string> NoPlatByOddOrEven(bool ganjil)
        {
            if (ganjil)
            {
                return _parking.GetFilledSlot().Where(slot => char.IsDigit(LastDigit(slot.Vehicle.NoPlat)) && int.Parse(LastDigit(slot.Vehicle.NoPlat).ToString()) % 2 != 0).
                    Select(slot => slot.Vehicle.NoPlat);
                
            }
            else
            {
                return _parking.GetFilledSlot().Where(slot =>
                char.IsDigit(LastDigit(slot.Vehicle.NoPlat)) && int.Parse(LastDigit(slot.Vehicle.NoPlat).ToString()) % 2 == 0).
                Select(slot => slot.Vehicle.NoPlat);
            }
        }

        public IEnumerable<string> NoPlatByColour(string colour)
        {
            return _parking.GetFilledSlot().Where(slot => slot.Vehicle.Warna.ToLower() == colour.ToLower()).Select(slot => slot.Vehicle.NoPlat);
        }

        public IEnumerable<int> SlotNumberByColour(string colour)
        {
            return _parking.GetFilledSlot().Where(slot => slot.Vehicle.Warna.ToLower() == colour.ToLower()).Select(slot => slot.NomorSlot);
        }

        public int? SlotNumberByNoPlat(string noPlat)
        {
            return _parking.GetFilledSlot().FirstOrDefault(slot => slot.Vehicle.NoPlat == noPlat)?.NomorSlot;
        }

        public void showNoPlatByOddOrEven(bool ganjil)
        {
            var noPlats = NoPlatByOddOrEven(ganjil).ToList();

            if (noPlats.Any())
            {
                foreach (var noPlat in noPlats)
                {
                    Console.WriteLine(noPlat);
                }
            }
            else
            {
                Console.WriteLine("No Vehicles wit " + (ganjil ? "odd plat" : "even plat"));
            }
        }

        private char LastDigit(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(str[i]))
                    {
                        return str[i];
                    }
                }
            }
            throw new Exception("No digit found in the string.");
        }

    }
}
