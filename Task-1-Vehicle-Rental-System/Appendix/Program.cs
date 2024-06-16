using System;

namespace VehicleRentalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Примери за данни на превозни средства
            Car car = new Car("Mitsubishi", "Mirage", 15000, 3);
            Motorcycle motorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 20);
            CargoVan cargoVan = new CargoVan("Citroen", "Jumper", 20000, 8);

            // Примери за данни на наеми
            Rental rentalCar = new Rental(car, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13));
            Rental rentalMotorcycle = new Rental(motorcycle, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13));
            Rental rentalCargoVan = new Rental(cargoVan, new DateTime(2024, 6, 3), new DateTime(2024, 6, 18), new DateTime(2024, 6, 13));

            // Генериране и отпечатване на фактури
            Invoice.GenerateInvoice("John Doe", rentalCar);
            Invoice.GenerateInvoice("Mary Johnson", rentalMotorcycle);
            Invoice.GenerateInvoice("John Markson", rentalCargoVan);
        }
    }

    abstract class Vehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public decimal Value { get; }

        public Vehicle(string brand, string model, decimal value)
        {
            Brand = brand;
            Model = model;
            Value = value;
        }

        public abstract decimal GetDailyRentalCost(int rentalDays);
        public abstract decimal GetInitialInsuranceCost();
        public abstract decimal GetAdjustedInsuranceCost();
        public abstract decimal GetInsuranceAdjustment();
    }

    class Car : Vehicle
    {
        public int SafetyRating { get; }

        public Car(string brand, string model, decimal value, int safetyRating)
            : base(brand, model, value)
        {
            SafetyRating = safetyRating;
        }

        public override decimal GetDailyRentalCost(int rentalDays)
        {
            return rentalDays > 7 ? 15m : 20m;
        }

        public override decimal GetInitialInsuranceCost()
        {
            return Value * 0.0001m;
        }

        public override decimal GetAdjustedInsuranceCost()
        {
            decimal baseInsurance = GetInitialInsuranceCost();
            return SafetyRating >= 4 ? baseInsurance * 0.9m : baseInsurance;
        }

        public override decimal GetInsuranceAdjustment()
        {
            decimal baseInsurance = GetInitialInsuranceCost();
            return SafetyRating >= 4 ? baseInsurance * 0.1m : 0;
        }
    }

    class Motorcycle : Vehicle
    {
        public int RiderAge { get; }

        public Motorcycle(string brand, string model, decimal value, int riderAge)
            : base(brand, model, value)
        {
            RiderAge = riderAge;
        }

        public override decimal GetDailyRentalCost(int rentalDays)
        {
            return rentalDays > 7 ? 10m : 15m;
        }

        public override decimal GetInitialInsuranceCost()
        {
            return Value * 0.0002m;
        }

        public override decimal GetAdjustedInsuranceCost()
        {
            decimal baseInsurance = GetInitialInsuranceCost();
            return RiderAge < 25 ? baseInsurance * 1.2m : baseInsurance;
        }

        public override decimal GetInsuranceAdjustment()
        {
            decimal baseInsurance = GetInitialInsuranceCost();
            return RiderAge < 25 ? baseInsurance * 0.2m : 0;
        }
    }

    class CargoVan : Vehicle
    {
        public int DriverExperience { get; }

        public CargoVan(string brand, string model, decimal value, int driverExperience)
            : base(brand, model, value)
        {
            DriverExperience = driverExperience;
        }

        public override decimal GetDailyRentalCost(int rentalDays)
        {
            return rentalDays > 7 ? 40m : 50m;
        }

        public override decimal GetInitialInsuranceCost()
        {
            return Value * 0.0003m;
        }

        public override decimal GetAdjustedInsuranceCost()
        {
            decimal baseInsurance = GetInitialInsuranceCost();
            return DriverExperience > 5 ? baseInsurance * 0.85m : baseInsurance;
        }

        public override decimal GetInsuranceAdjustment()
        {
            decimal baseInsurance = GetInitialInsuranceCost();
            return DriverExperience > 5 ? baseInsurance * 0.15m : 0;
        }
    }

    class Rental
    {
        public Vehicle RentedVehicle { get; }
        public DateTime ReservationStartDate { get; }
        public DateTime ReservationEndDate { get; }
        public DateTime ActualReturnDate { get; }

        public Rental(Vehicle rentedVehicle, DateTime reservationStartDate, DateTime reservationEndDate, DateTime actualReturnDate)
        {
            RentedVehicle = rentedVehicle;
            ReservationStartDate = reservationStartDate;
            ReservationEndDate = reservationEndDate;
            ActualReturnDate = actualReturnDate;
        }

        public int GetReservedRentalDays()
        {
            return (ReservationEndDate - ReservationStartDate).Days;
        }

        public int GetActualRentalDays()
        {
            return (ActualReturnDate - ReservationStartDate).Days;
        }

        public decimal CalculateTotalRentalCost(out decimal earlyReturnDiscount)
        {
            int reservedDays = GetReservedRentalDays();
            int actualDays = GetActualRentalDays();
            decimal dailyRentalCost = RentedVehicle.GetDailyRentalCost(reservedDays);

            if (actualDays < reservedDays)
            {
                earlyReturnDiscount = (reservedDays - actualDays) * dailyRentalCost / 2;
                return (actualDays * dailyRentalCost) + ((reservedDays - actualDays) * dailyRentalCost / 2);
            }
            earlyReturnDiscount = 0;
            return actualDays * dailyRentalCost;
        }

        public decimal CalculateTotalInsuranceCost(out decimal earlyReturnInsuranceDiscount)
        {
            int reservedDays = GetReservedRentalDays();
            int actualDays = GetActualRentalDays();
            decimal dailyInsuranceCost = RentedVehicle.GetAdjustedInsuranceCost();

            if (actualDays < reservedDays)
            {
                earlyReturnInsuranceDiscount = (reservedDays - actualDays) * dailyInsuranceCost;
                return actualDays * dailyInsuranceCost;
            }
            earlyReturnInsuranceDiscount = 0;
            return actualDays * dailyInsuranceCost;
        }
    }

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
