// Adding event listeners
document.getElementById('leasingForm').addEventListener('input', calculateLeasing);
document.getElementById('carValue').addEventListener('input', syncCarValueRange);
document.getElementById('downPayment').addEventListener('input', syncDownPaymentRange);

function calculateLeasing() {
  // Getting the values from the form inputs
  const carType = document.getElementById('carType').value;
  const carValue = parseFloat(document.getElementById('carValue').value);
  const leasePeriod = parseInt(document.getElementById('leasePeriod').value);
  const downPaymentPercent = parseFloat(document.getElementById('downPayment').value);

  // if the value is not valid, set it to 0 so the user can't submit an invalid form
  if (!carValue || carValue < 10000 || carValue > 200000 || !downPaymentPercent || downPaymentPercent < 10 || downPaymentPercent > 50) {
    document.getElementById('totalLeasingCost').innerText = '0.00';
    document.getElementById('monthlyInstallment').innerText = '0.00';
    document.getElementById('downPaymentAmount').innerText = '0.00';
    document.getElementById('interestRate').innerText = '0.00';
    return;
  }

  // Calculating the down payment amount
  const downPaymentAmount = (carValue * downPaymentPercent) / 100;

  // Calculating the principal amount
  const principalAmount = carValue - downPaymentAmount;

  // Setting the interest rate based on the car type
  const interestRate = carType === 'brandNew' ? 2.99 : 3.7;

  // Calculating the monthly interest rate
  const monthlyInterestRate = interestRate / 100 / 12;

  // Calculating the monthly installment using the principal amount and monthly interest rate
  const monthlyInstallment = (principalAmount * monthlyInterestRate) / (1 - Math.pow(1 + monthlyInterestRate, -leasePeriod));

  // Calculating the total leasing cost by adding the down payment amount and the total of monthly installments
  const totalLeasingCost = downPaymentAmount + monthlyInstallment * leasePeriod;

  // Updating the UI with the calculated values by using Id selectors in the HTML and rounding the values to 2 decimal places
  document.getElementById('totalLeasingCost').innerText = totalLeasingCost.toFixed(2);
  document.getElementById('monthlyInstallment').innerText = monthlyInstallment.toFixed(2);
  document.getElementById('downPaymentAmount').innerText = downPaymentAmount.toFixed(2);
  document.getElementById('interestRate').innerText = interestRate.toFixed(2);
}

// Function to synchronize the car value input with the range slider and recalculate leasing
function syncCarValue() {
  document.getElementById('carValue').value = document.getElementById('carValueRange').value;
  calculateLeasing();
}

// Function to synchronize the down payment input with the range slider and recalculate leasing
function syncDownPayment() {
  document.getElementById('downPayment').value = document.getElementById('downPaymentRange').value;
  calculateLeasing();
}

// Function to synchronize the car value range slider with the input
function syncCarValueRange() {
  document.getElementById('carValueRange').value = document.getElementById('carValue').value;
}

// Function to synchronize the down payment range slider with the input
function syncDownPaymentRange() {
  document.getElementById('downPaymentRange').value = document.getElementById('downPayment').value;
}
