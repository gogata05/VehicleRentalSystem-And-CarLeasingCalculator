using System;

namespace VehicleRentalSystem
{
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
}