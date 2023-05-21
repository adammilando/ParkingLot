using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class PrakingSlot
    {
        public int NomorSlot { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime WaktuParir { get; set; }

        public PrakingSlot(int nomorSlot)
        {
            NomorSlot = nomorSlot;
        }

        public bool IsAvailable()
        {
            return Vehicle == null;
        }

        public void VehiclePark(Vehicle vehicle)
        {
            Vehicle = vehicle;
            WaktuParir = DateTime.Now;
        }

        public void VehicleOut()
        {
            Vehicle = null;
        }
    }
}
