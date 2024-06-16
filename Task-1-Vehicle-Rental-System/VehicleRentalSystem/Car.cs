using System;

namespace VehicleRentalSystem
{
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
}