// Adding event listeners
document.getElementById('leasingForm')!.addEventListener('input', calculateLeasing);
document.getElementById('carValue')!.addEventListener('input', syncCarValueRange);
document.getElementById('carValueRange')!.addEventListener('input', syncCarValue);
document.getElementById('downPayment')!.addEventListener('input', syncDownPaymentRange);
document.getElementById('downPaymentRange')!.addEventListener('input', syncDownPayment);

function calculateLeasing(): void {
  const carType = (document.getElementById('carType') as HTMLSelectElement).value;
  const carValue = parseFloat((document.getElementById('carValue') as HTMLInputElement).value);
  const leasePeriod = parseInt((document.getElementById('leasePeriod') as HTMLSelectElement).value);
  const downPaymentPercent = parseFloat((document.getElementById('downPayment') as HTMLInputElement).value);

  // if the value is not valid, set it to 0 so the user can't submit an invalid form
  if (!carValue || carValue < 10000 || carValue > 200000 || !downPaymentPercent || downPaymentPercent < 10 || downPaymentPercent > 50) {
    setValuesToZero();
    return;
  }

  const downPaymentAmount = (carValue * downPaymentPercent) / 100;
  const principalAmount = carValue - downPaymentAmount;
  const interestRate = carType === 'brandNew' ? 2.99 : 3.7;
  const monthlyInterestRate = interestRate / 100 / 12;
  const monthlyInstallment = (principalAmount * monthlyInterestRate) / (1 - Math.pow(1 + monthlyInterestRate, -leasePeriod));
  const totalLeasingCost = downPaymentAmount + monthlyInstallment * leasePeriod;

  (document.getElementById('totalLeasingCost') as HTMLElement).innerText = totalLeasingCost.toFixed(2);
  (document.getElementById('monthlyInstallment') as HTMLElement).innerText = monthlyInstallment.toFixed(2);
  (document.getElementById('downPaymentAmount') as HTMLElement).innerText = downPaymentAmount.toFixed(2);
  (document.getElementById('interestRate') as HTMLElement).innerText = interestRate.toFixed(2);
}

function setValuesToZero(): void {
  (document.getElementById('totalLeasingCost') as HTMLElement).innerText = '0.00';
  (document.getElementById('monthlyInstallment') as HTMLElement).innerText = '0.00';
  (document.getElementById('downPaymentAmount') as HTMLElement).innerText = '0.00';
  (document.getElementById('interestRate') as HTMLElement).innerText = '0.00';
}

function syncCarValue(): void {
  const carValueRange = document.getElementById('carValueRange') as HTMLInputElement;
  const carValue = document.getElementById('carValue') as HTMLInputElement;
  carValue.value = carValueRange.value;
  calculateLeasing();
}

function syncDownPayment(): void {
  const downPaymentRange = document.getElementById('downPaymentRange') as HTMLInputElement;
  const downPayment = document.getElementById('downPayment') as HTMLInputElement;
  downPayment.value = downPaymentRange.value;
  calculateLeasing();
}

function syncCarValueRange(): void {
  const carValueRange = document.getElementById('carValueRange') as HTMLInputElement;
  const carValue = document.getElementById('carValue') as HTMLInputElement;
  carValueRange.value = carValue.value;
  calculateLeasing();
}

function syncDownPaymentRange(): void {
  const downPaymentRange = document.getElementById('downPaymentRange') as HTMLInputElement;
  const downPayment = document.getElementById('downPayment') as HTMLInputElement;
  downPaymentRange.value = downPayment.value;
  calculateLeasing();
}
