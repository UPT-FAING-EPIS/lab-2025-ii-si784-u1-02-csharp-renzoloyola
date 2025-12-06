using Bank.WebApi.Models;
using NUnit.Framework;

namespace Bank.WebApi.Tests
{
    /// <summary>
    /// Pruebas unitarias para la clase BankAccount.
    /// </summary>
    public class BankAccountTests
    {
        /// <summary>
        /// Verifica que el débito con un monto válido actualice correctamente el saldo.
        /// </summary>
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not debited correctly");
        }

        /// <summary>
        /// Verifica que el crédito con un monto válido actualice correctamente el saldo.
        /// </summary>
        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            double expected = 16.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Credit(creditAmount);
            // Assert
            double actual = account.Balance;
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Account not credited correctly");
        }

        /// <summary>
        /// Verifica que el débito con monto negativo lance una excepción.
        /// </summary>
        [Test]
        public void Debit_WithNegativeAmount_ThrowsArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -5.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        /// <summary>
        /// Verifica que el débito con monto mayor al saldo lance una excepción.
        /// </summary>
        [Test]
        public void Debit_WithAmountGreaterThanBalance_ThrowsArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
    }
}

