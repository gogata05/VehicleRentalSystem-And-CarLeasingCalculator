using System;

namespace VehicleRentalSystem
{
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
}