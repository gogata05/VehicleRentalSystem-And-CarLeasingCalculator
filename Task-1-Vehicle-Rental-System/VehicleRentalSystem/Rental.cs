using System;

namespace VehicleRentalSystem
{
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
}
