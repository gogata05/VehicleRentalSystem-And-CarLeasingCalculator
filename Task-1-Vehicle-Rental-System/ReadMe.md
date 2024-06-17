# Vehicle Rental System

## Overview
This project is a Vehicle Rental System that allows users to rent various types of vehicles such as cars, motorcycles, and cargo vans. The application calculates rental costs, insurance, and generates invoices for the rentals.

## Approach

### Step-by-Step Implementation

#### Step 1: Creating the Vehicle Class
1. **Vehicle.cs:**
   - Created an abstract base class `Vehicle` with common properties like `Brand`, `Model`, and `Value`.
   - Added abstract methods for calculating rental cost and insurance.

#### Step 2: Implementing Specific Vehicle Classes And Using Inheritance
1. **Car.cs:**
   - Created a `Car` class that inherits from `Vehicle`.
   - Implemented methods for calculating daily rental cost and insurance adjustments based on safety ratings.

2. **Motorcycle.cs:**
   - Created a `Motorcycle` class that inherits from `Vehicle`.
   - Implemented methods for calculating daily rental cost and insurance adjustments based on rider age.

3. **CargoVan.cs:**
   - Created a `CargoVan` class that inherits from `Vehicle`.
   - Implemented methods for calculating daily rental cost and insurance adjustments based on driver experience.

#### Step 3: Creating the Rental Class
1. **Rental.cs:**
   - Created a `Rental` class to handle rental details including the vehicle being rented, reservation dates, and actual return dates.
   - Implemented methods to calculate the total rental cost and insurance cost, including discounts for early returns.

#### Step 4: Generating Invoices
1. **Invoice.cs:**
   - Created a static `Invoice` class to generate and print invoices.
   - Implemented a method to format and display detailed rental and insurance costs.

#### Step 5: Integrating All Components
1. **Program.cs:**
   - Integrated all the components by creating instances of `Car`, `Motorcycle`, and `CargoVan`.
   - Created `Rental` instances for each vehicle.
   - Used the `Invoice` class to generate invoices for each rental.

### File Structure
The final project structure looks like this:
VehicleRentalSystem

```
│
├── Program.cs
├── Vehicle.cs
├── Car.cs
├── Motorcycle.cs
├── CargoVan.cs
├── Rental.cs
└── Invoice.cs
```

## How to Use

1. Clone repository.
2. Open "VehicleRentalSystem.sln" with Visual Studio 2022.
3. Ctrl+F5

### Photos

Console Output:

![image](https://imgur.com/JQQDj8e.png)

