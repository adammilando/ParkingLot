using ParkingLot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Repository
{
    public class Parking
    {
        private List<PrakingSlot> Slots { get; set; }

        public Parking(int jumlahSlot)
        {
            Slots = new List<PrakingSlot>();
            for (int i = 1; i <= jumlahSlot; i++)
            {
                Slots.Add(new PrakingSlot(i));
            }
        }

        public PrakingSlot FindAvailableSlot()
        {
            return Slots.FirstOrDefault(slots => slots.IsAvailable());
        }

        public void VehiclePark(Vehicle vehicle)
        {
            var availableSlot = FindAvailableSlot();
            if (availableSlot != null)
            {
                availableSlot.VehiclePark(vehicle);
                Console.WriteLine($"Allocated slot number: {availableSlot.NomorSlot}");
            }
            else
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
        }

        public void VehicleLiving(int nomorSlot)
        {
            var slot = Slots.FirstOrDefault(s => s.NomorSlot == nomorSlot);
            if (slot != null && !slot.IsAvailable()) {
                slot.VehicleOut();
                Console.WriteLine($"Slot number {nomorSlot} is free");
            }
            else
            {
                Console.WriteLine($"Slot number {nomorSlot} is already free");
            }
        }

        public IEnumerable<PrakingSlot> GetFilledSlot()
        {
            return Slots.Where(slot => !slot.IsAvailable());
        }

        public void ParkingStatus()
        {
            foreach (var slot in Slots)
            {
                if (!slot.IsAvailable())
                {
                    Console.WriteLine($"Slot: {slot.NomorSlot}, No. Plat: {slot.Vehicle.NoPlat}, Type: {slot.Vehicle.VehicleType}, Colour: {slot.Vehicle.Warna}");
                }
            }
        }

        
    }
}
