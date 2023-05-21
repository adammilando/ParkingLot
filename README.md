# Parking Lot System

This repository holds the source code for a simple command-line parking lot system developed in C#.

## Features

The parking lot system provides the following features:

1. **Park a vehicle**: Park a vehicle in the parking lot if slots are available.
2. **Leave the parking**: Remove a vehicle from the parking lot.
3. **Check status**: Show the status of the parking lot, including all parked vehicles and their details.
4. **Get total vehicles by type**: Count the total number of a particular type of vehicles currently parked.
5. **Registration numbers for vehicles with odd/even plate**: List all vehicles with registration numbers having odd or even last digit.
6. **Registration numbers for vehicles with a particular color**: List all vehicles of a specific color.
7. **Slot numbers for vehicles with a particular color**: Show all parking slots occupied by vehicles of a specific color.
8. **Slot number for a specific registration number**: Show the parking slot number for a vehicle with a specific registration number.

## Instructions

After cloning the repository and navigating into the project directory, run the program via your C# compiler (e.g., `dotnet run`). When the program is started, it will first ask you to enter the number of slots in the parking lot.

Then, the program will continuously prompt for commands until the `exit` command is given. Commands should be entered as described below:

- To park a vehicle: `park <plate_number> <color> <type>`
- To remove a vehicle from the parking lot: `leave <slot_number>`
- To display the parking lot status: `status`
- To count vehicles of a particular type: `type_of_vehicles <type>`
- To list vehicles with odd/even numbered plates: `registration_numbers_for_vehicles_with_odd_plate` or `registration_numbers_for_vehicles_with_even_plate`
- To list vehicles of a specific color: `registration_numbers_for_vehicles_with_colour <color>`
- To show parking slots occupied by vehicles of a specific color: `slot_numbers_for_vehicles_with_colour <color>`
- To find the slot of a vehicle by its plate number: `slot_number_for_registration_number <plate_number>`
- To exit the program: `exit`
