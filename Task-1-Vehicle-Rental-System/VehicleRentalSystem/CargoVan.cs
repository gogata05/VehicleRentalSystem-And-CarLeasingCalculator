using System;

namespace VehicleRentalSystem
{
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
}