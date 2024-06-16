// Adding event listeners
document.getElementById('leasingForm')!.addEventListener('input', calculateLeasing);
document.getElementById('carValue')!.addEventListener('input', syncCarValueRange);
document.getElementById('carValueRange')!.addEventListener('input', syncCarValue);
document.getElementById('downPayment')!.addEventListener('input', syncDownPaymentRange);
document.getElementById('downPaymentRange')!.addEventListener('input', syncDownPayment);

function calculateLeasing(): void {
  // Getting the values from the form inputs
  const carType = (document.getElementById('carType') as HTMLSelectElement).value;
  const carValue = parseFloat((document.getElementById('carValue') as HTMLInputElement).value);
  const leasePeriod = parseInt((document.getElementById('leasePeriod') as HTMLSelectElement).value);
  const downPaymentPercent = parseFloat((document.getElementById('downPayment') as HTMLInputElement).value);

  // if the value is not valid, set it to 0 so the user can't submit an invalid form
  if (!carValue || carValue < 10000 || carValue > 200000 || !downPaymentPercent || downPaymentPercent < 10 || downPaymentPercent > 50) {
    setValuesToZero();
    return;
  }

  // Calculating the down payment amount
  const downPaymentAmount = (carValue * downPaymentPercent) / 100;

  // Calculating the principal
  const principalAmount = carValue - downPaymentAmount;

  // Setting the interest rate based on the car type
  const interestRate = carType === 'brandNew' ? 2.99 : 3.7;

  // Calculating the monthly interest rate
  const monthlyInterestRate = interestRate / 100 / 12;

  // Calculating the monthly installment using the principal amount and monthly interest rate
  const monthlyInstallment = (principalAmount * monthlyInterestRate) / (1 - Math.pow(1 + monthlyInterestRate, -leasePeriod));

  // Calculating the total leasing cost
  const totalLeasingCost = downPaymentAmount + monthlyInstallment * leasePeriod;

  // Updating the UI with the calculated values by using Id selectors in the HTML and rounding the values to 2 decimal places
  (document.getElementById('totalLeasingCost') as HTMLElement).innerText = totalLeasingCost.toFixed(2);
  (document.getElementById('monthlyInstallment') as HTMLElement).innerText = monthlyInstallment.toFixed(2);
  (document.getElementById('downPaymentAmount') as HTMLElement).innerText = downPaymentAmount.toFixed(2);
  (document.getElementById('interestRate') as HTMLElement).innerText = interestRate.toFixed(2);
}

// Function to set the values to zero if the input is not valid
function setValuesToZero(): void {
  (document.getElementById('totalLeasingCost') as HTMLElement).innerText = '0.00';
  (document.getElementById('monthlyInstallment') as HTMLElement).innerText = '0.00';
  (document.getElementById('downPaymentAmount') as HTMLElement).innerText = '0.00';
  (document.getElementById('interestRate') as HTMLElement).innerText = '0.00';
}

// Function to synchronize the car value input with the range slider
function syncCarValue(): void {
  const carValueRange = document.getElementById('carValueRange') as HTMLInputElement;
  const carValue = document.getElementById('carValue') as HTMLInputElement;
  carValue.value = carValueRange.value;
  calculateLeasing();
}

// Function to synchronize the down payment input with the range slider
function syncDownPayment(): void {
  const downPaymentRange = document.getElementById('downPaymentRange') as HTMLInputElement;
  const downPayment = document.getElementById('downPayment') as HTMLInputElement;
  downPayment.value = downPaymentRange.value;
  calculateLeasing();
}

// Function to synchronize the car value range slider with the input
function syncCarValueRange(): void {
  const carValueRange = document.getElementById('carValueRange') as HTMLInputElement;
  const carValue = document.getElementById('carValue') as HTMLInputElement;
  carValueRange.value = carValue.value;
  calculateLeasing();
}

// Function to synchronize the down payment range slider with the input
function syncDownPaymentRange(): void {
  const downPaymentRange = document.getElementById('downPaymentRange') as HTMLInputElement;
  const downPayment = document.getElementById('downPayment') as HTMLInputElement;
  downPaymentRange.value = downPayment.value;
  calculateLeasing();
}
