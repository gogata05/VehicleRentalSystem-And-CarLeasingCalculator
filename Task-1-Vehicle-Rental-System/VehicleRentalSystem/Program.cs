using System;

namespace VehicleRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vehicles to be rented
            Car car = new Car("Mitsubishi", "Mirage", 15000, 3);
            Motorcycle motorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 20);
            CargoVan cargoVan = new CargoVan("Citroen", "Jumper", 20000, 8);

            // Data for rental
            Rental rentalCar = new Rental(car, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13));
            Rental rentalMotorcycle = new Rental(motorcycle, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13));
            Rental rentalCargoVan = new Rental(cargoVan, new DateTime(2024, 6, 3), new DateTime(2024, 6, 18), new DateTime(2024, 6, 13));

            // Generate and print invoices
            Invoice.GenerateInvoice("John Doe", rentalCar);
            Invoice.GenerateInvoice("Mary Johnson", rentalMotorcycle);
            Invoice.GenerateInvoice("John Markson", rentalCargoVan);
        }
    }
}