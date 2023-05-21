using ParkingLot.Models;
using ParkingLot.Repository;
using ParkingLot.Service;
using ParkingLot.Utils;
using System;

namespace ParkingLot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan jumlah slot: ");
            int jumlahSlot = int.Parse(Console.ReadLine());
            var parking = new Parking(jumlahSlot);
            var laporan = new Report(parking);

            while (true)
            {
                //Tolong lihat github saya untuk cara menggunakan perintah dibawah ini
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("silahkan gunakan perintah yang ada dibawah ini:");
                Console.WriteLine("\tpark");
                Console.WriteLine("\tleave");
                Console.WriteLine("\tstatus");
                Console.WriteLine("\ttype_of_vehicles");
                Console.WriteLine("\tregistration_numbers_for_vehicles_with_odd_plate");
                Console.WriteLine("\tregistration_numbers_for_vehicles_with_event_plate");
                Console.WriteLine("\tregistration_numbers_for_vehicles_with_colour");
                Console.WriteLine("\tslot_numbers_for_vehicles_with_colour");
                Console.WriteLine("\tslot_number_for_registration_number");
                Console.WriteLine("\texit");
                Console.Write("Masukkan perintah: ");

                var perintah = Console.ReadLine().Split();

                if (perintah[0] == "exit")
                {
                    break;
                }

                Console.WriteLine("--------------------------------------------------------------------------------");

                switch (perintah[0])
                {
                    case "park":
                        if (perintah.Length < 4)
                        {
                            Console.WriteLine("Perintah 'park' membutuhkan 3 argumen: nomor plat, warna, dan tipe kendaraan.");
                            break;
                        }
                        if (perintah[3] != "Mobil" && perintah[3] != "Motor")
                        {
                            Console.WriteLine("Tipe kendaraan harus 'Mobil' atau 'Motor'.");
                            break;
                        }
                        if (!System.Text.RegularExpressions.Regex.IsMatch(perintah[1], @"^[A-Z]-\d{4}-[A-Z]{3}$"))
                        {
                            Console.WriteLine("Nomor plat harus dalam format: B-1234-XYZ");
                            break;
                        }
                        parking.VehiclePark(new Vehicle(perintah[1], perintah[2], perintah[3] == "Mobil" ? VehicleType.Mobil : VehicleType.Motor));
                        break;
                    case "leave":
                        if (perintah.Length < 2)
                        {
                            Console.WriteLine("Perintah 'leave' membutuhkan 1 argumen: nomor slot.");
                            break;
                        }
                        int slotNum;
                        if (!int.TryParse(perintah[1], out slotNum))
                        {
                            Console.WriteLine("Nomor slot harus berupa angka.");
                            break;
                        }
                        parking.VehicleLiving(slotNum);
                        break;
                    case "status":
                        parking.ParkingStatus();
                        break;
                    case "type_of_vehicles":
                        if (perintah.Length < 2 || (perintah[1] != "Mobil" && perintah[1] != "Motor"))
                        {
                            Console.WriteLine("Perintah 'type_of_vehicles' membutuhkan 1 argumen: tipe kendaraan ('Mobil' atau 'Motor').");
                            break;
                        }
                        Console.WriteLine($"Total {perintah[1]} in parking lot: {laporan.TotalVehicleByType(perintah[1] == "Mobil" ? VehicleType.Mobil : VehicleType.Motor)}");
                        break;
                    case "registration_numbers_for_vehicles_with_odd_plate":
                        laporan.showNoPlatByOddOrEven(true);
                        break;
                    case "registration_numbers_for_vehicles_with_event_plate":
                        laporan.showNoPlatByOddOrEven(false);
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        if (perintah.Length < 2)
                        {
                            Console.WriteLine("Perintah 'registration_numbers_for_vehicles_with_colour' membutuhkan 1 argumen: warna.");
                            break;
                        }
                        Console.WriteLine($"Vehicle plate numbers for color {perintah[1]}: " + string.Join(", ", laporan.NoPlatByColour(perintah[1])));
                        break;

                    case "slot_numbers_for_vehicles_with_colour":
                        if (perintah.Length < 2)
                        {
                            Console.WriteLine("Perintah 'slot_numbers_for_vehicles_with_colour' membutuhkan 1 argumen: warna.");
                            break;
                        }
                        Console.WriteLine($"Slot numbers for color {perintah[1]}: " + string.Join(", ", laporan.SlotNumberByColour(perintah[1])));
                        break;

                    case "slot_number_for_registration_number":
                        if (perintah.Length < 2)
                        {
                            Console.WriteLine("Perintah 'slot_number_for_registration_number' membutuhkan 1 argumen: nomor plat.");
                            break;
                        }
                        var nomorSlot = laporan.SlotNumberByNoPlat(perintah[1]);
                        if (nomorSlot.HasValue)
                        {
                            Console.WriteLine($"Slot number for vehicle with plate number {perintah[1]}: {nomorSlot.Value}");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle with such plate number not found.");
                        }
                        break;
                    default:
                        Console.WriteLine("Perintah tidak valid");
                        break;
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }
    }
}
