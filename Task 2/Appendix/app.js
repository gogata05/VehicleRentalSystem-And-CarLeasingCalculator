document.getElementById('leasingForm').addEventListener('input', calculateLeasing);

function calculateLeasing() {
  const carType = document.getElementById('carType').value;
  const carValue = parseFloat(document.getElementById('carValue').value);
  const leasePeriod = parseInt(document.getElementById('leasePeriod').value);
  const downPaymentPercent = parseFloat(document.getElementById('downPayment').value);

  if (!carValue || !leasePeriod || !downPaymentPercent) return;

  const downPaymentAmount = (carValue * downPaymentPercent) / 100;
  const principalAmount = carValue - downPaymentAmount;
  const interestRate = carType === 'brandNew' ? 2.99 : 3.7;
  const monthlyInterestRate = interestRate / 100 / 12;
  const monthlyInstallment = (principalAmount * monthlyInterestRate) / (1 - Math.pow(1 + monthlyInterestRate, -leasePeriod));
  const totalLeasingCost = downPaymentAmount + monthlyInstallment * leasePeriod;

  document.getElementById('totalLeasingCost').innerText = totalLeasingCost.toFixed(2);
  document.getElementById('monthlyInstallment').innerText = monthlyInstallment.toFixed(2);
  document.getElementById('downPaymentAmount').innerText = downPaymentAmount.toFixed(2);
  document.getElementById('interestRate').innerText = interestRate.toFixed(2);
}
