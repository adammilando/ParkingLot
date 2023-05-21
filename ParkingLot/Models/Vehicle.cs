using ParkingLot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot.Models
{
    public class Vehicle
    {
        public string NoPlat { get; set; }
        public string Warna { get; set; }
        public VehicleType VehicleType { get; set; }

        public Vehicle(string noPlat, string warna, VehicleType vehicleType)
        {
            NoPlat = noPlat;
            Warna = warna;
            VehicleType = vehicleType;
        }
    }
}
