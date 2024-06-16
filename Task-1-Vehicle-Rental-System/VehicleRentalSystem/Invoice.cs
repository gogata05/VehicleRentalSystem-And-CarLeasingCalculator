using System;

namespace VehicleRentalSystem
{
    static class Invoice
    {
        public static void GenerateInvoice(string customerName, Rental rental)
        {
            decimal earlyReturnDiscount;
            decimal totalRentalCost = rental.CalculateTotalRentalCost(out earlyReturnDiscount);

            decimal earlyReturnInsuranceDiscount;
            decimal totalInsuranceCost = rental.CalculateTotalInsuranceCost(out earlyReturnInsuranceDiscount);

            decimal totalCost = totalRentalCost + totalInsuranceCost;

            // Извеждане на типа на превозното средство и съответните данни
            if (rental.RentedVehicle is Car car)
            {
                Console.WriteLine($"A car that is valued at ${car.Value.ToString("N2")}, and has a security rating of {car.SafetyRating}");
            }
            else if (rental.RentedVehicle is Motorcycle motorcycle)
            {
                Console.WriteLine($"A motorcycle valued at ${motorcycle.Value.ToString("N2")}, and the driver is {motorcycle.RiderAge} years old");
            }
            else if (rental.RentedVehicle is CargoVan cargoVan)
            {
                Console.WriteLine($"A cargo van valued at ${cargoVan.Value.ToString("N2")}, and the driver has {cargoVan.DriverExperience} years of driving experience");
            }

            Console.WriteLine("XXXXXXXXXXXX");
            Console.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Rented Vehicle: {rental.RentedVehicle.Brand} {rental.RentedVehicle.Model}");
            Console.WriteLine();
            Console.WriteLine($"Reservation start date: {rental.ReservationStartDate:yyyy-MM-dd}");
            Console.WriteLine($"Reservation end date: {rental.ReservationEndDate:yyyy-MM-dd}");
            Console.WriteLine($"Reserved rental days: {rental.GetReservedRentalDays()} days");
            Console.WriteLine();
            Console.WriteLine($"Actual return date: {rental.ActualReturnDate:yyyy-MM-dd}");
            Console.WriteLine($"Actual rental days: {rental.GetActualRentalDays()} days");
            Console.WriteLine();
            Console.WriteLine($"Rental cost per day: {rental.RentedVehicle.GetDailyRentalCost(rental.GetReservedRentalDays()):C2}");
            Console.WriteLine($"Initial insurance per day: {rental.RentedVehicle.GetInitialInsuranceCost():C2}");

            if (rental.RentedVehicle is Car)
            {
                car = (Car)rental.RentedVehicle;
                if (car.SafetyRating >= 4)
                {
                    Console.WriteLine($"Insurance discount per day: {rental.RentedVehicle.GetInsuranceAdjustment():C2}");
                }
            }
            else if (rental.RentedVehicle is Motorcycle motorcycle)
            {
                if (motorcycle.RiderAge < 25)
                {
                    Console.WriteLine($"Insurance addition per day: {rental.RentedVehicle.GetInsuranceAdjustment():C2}");
                }
            }
            else if (rental.RentedVehicle is CargoVan cargoVan)
            {
                if (cargoVan.DriverExperience > 5)
                {
                    Console.WriteLine($"Insurance discount per day: {rental.RentedVehicle.GetInsuranceAdjustment():C2}");
                }
            }

            Console.WriteLine($"Insurance per day: {rental.RentedVehicle.GetAdjustedInsuranceCost():C2}");
            Console.WriteLine();
            if (earlyReturnDiscount > 0)
            {
                Console.WriteLine($"Early return discount for rent: {earlyReturnDiscount:C2}");
                Console.WriteLine($"Early return discount for insurance: {earlyReturnInsuranceDiscount:C2}");
                Console.WriteLine();
            }
            Console.WriteLine($"Total rent: {totalRentalCost:C2}");
            Console.WriteLine($"Total Insurance: {totalInsuranceCost:C2}");
            Console.WriteLine();
            Console.WriteLine($"Total: {totalCost:C2}");
            Console.WriteLine("XXXXXXXXXXXX");
            Console.WriteLine();
        }
    }
}
