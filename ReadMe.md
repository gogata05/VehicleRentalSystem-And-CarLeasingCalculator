# Task 1

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

# Task 2

# Car Leasing Calculator

## Overview

Our company is developing a user-friendly car leasing calculator to assist potential customers in estimating their monthly leasing costs. As part of our front-end development team, you'll be responsible for creating an intuitive web interface that allows users to input relevant details and receive accurate leasing information.

## Project Requirements

### User Interface (UI)

- Design a clean and professional UI for the calculator using HTML and CSS.
- Ensure the form elements are well-organized and visually appealing.
- Implement responsive design to accommodate various screen sizes.
- Pictures are added to the Appendix section.

### Functionality

- Develop the calculator logic using vanilla JavaScript.
- Capture the following user inputs:
  - Car type (brand new or used)
    - A dropdown list with the two options
  - Car value (within the range of €10,000 to €200,000)
    - A text input field for the value
    - A range input field for the value
  - Lease period (selectable from 12 to 60 months, in 12-month increments)
    - A text input field
    - A range input field for the period
  - Down payment (between 10% and 50% of the car value)
    - A range input field with an increment of 5%
- Calculate the monthly installment based on the selected parameters.
- Display the leasing cost, down payment, monthly installment, and interest rate.
- All the inputs must dynamically change the results (no button to execute the calculation is required).

### Business Rules

- For brand-new cars, apply an annual interest rate of 2.99%.
- For used cars, use an annual interest rate of 3.7%.
- Validate user inputs to prevent invalid values.

### Results Display

- Provide a clear breakdown of the leasing cost components.
- Show the calculated results below the form in two columns.
  - Left column:
    - Leasing cost
    - Down payment (Down payment %)
  - Right column:
    - Monthly installment
    - Interest rate

### Evaluation Criteria

- Code quality: Well-structured, maintainable, and commented code.
- Accuracy: Ensure accurate calculations and adherence to business rules.
- User experience: Intuitive interface and error handling.
- Responsiveness: Compatibility across different devices.

## Approach

### Step-by-Step Implementation

#### Step 1: Setting Up the Project

1. **index.html:**

   - Created the HTML structure with form elements to capture user inputs.
   - Included necessary IDs for JavaScript to access and manipulate the DOM elements.

2. **style.css:**

   - Designed the UI using CSS to ensure a clean and professional look.
   - Implemented responsive design to accommodate various screen sizes.

3. **app.js:**
   - Developed the calculator logic using vanilla JavaScript.
   - Added event listeners to form elements to dynamically calculate and update leasing costs based on user inputs.

### File Structure

The final project structure looks like this:

```
CarLeasingCalculator
│
├── index.html
├── style.css
└── app.js
```

## How to use?

- 1.Clone Repo
- 2.Open with Visual Studio Code
- 3.Use Live Server

### Photos

Web:

![image](../VehicleRentalSystem-And-CarLeasingCalculator/Task-2-Car-Leasing-Calculator/Images/task2Web.png)

Mobile:

![image](../VehicleRentalSystem-And-CarLeasingCalculator/Task-2-Car-Leasing-Calculator/Images/task2Mobile.png)
