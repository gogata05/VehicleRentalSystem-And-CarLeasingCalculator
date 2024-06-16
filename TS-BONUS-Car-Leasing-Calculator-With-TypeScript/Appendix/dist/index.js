// Adding event listeners
document.getElementById('leasingForm').addEventListener('input', calculateLeasing);
document.getElementById('carValue').addEventListener('input', syncCarValueRange);
document.getElementById('carValueRange').addEventListener('input', syncCarValue);
document.getElementById('downPayment').addEventListener('input', syncDownPaymentRange);
document.getElementById('downPaymentRange').addEventListener('input', syncDownPayment);
function calculateLeasing() {
    const carType = document.getElementById('carType').value;
    const carValue = parseFloat(document.getElementById('carValue').value);
    const leasePeriod = parseInt(document.getElementById('leasePeriod').value);
    const downPaymentPercent = parseFloat(document.getElementById('downPayment').value);
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
    document.getElementById('totalLeasingCost').innerText = totalLeasingCost.toFixed(2);
    document.getElementById('monthlyInstallment').innerText = monthlyInstallment.toFixed(2);
    document.getElementById('downPaymentAmount').innerText = downPaymentAmount.toFixed(2);
    document.getElementById('interestRate').innerText = interestRate.toFixed(2);
}
function setValuesToZero() {
    document.getElementById('totalLeasingCost').innerText = '0.00';
    document.getElementById('monthlyInstallment').innerText = '0.00';
    document.getElementById('downPaymentAmount').innerText = '0.00';
    document.getElementById('interestRate').innerText = '0.00';
}
function syncCarValue() {
    document.getElementById('carValue').value = document.getElementById('carValueRange').value;
    calculateLeasing();
}
function syncDownPayment() {
    document.getElementById('downPayment').value = document.getElementById('downPaymentRange').value;
    calculateLeasing();
}
function syncCarValueRange() {
    document.getElementById('carValueRange').value = document.getElementById('carValue').value;
    calculateLeasing();
}
function syncDownPaymentRange() {
    document.getElementById('downPaymentRange').value = document.getElementById('downPayment').value;
    calculateLeasing();
}
