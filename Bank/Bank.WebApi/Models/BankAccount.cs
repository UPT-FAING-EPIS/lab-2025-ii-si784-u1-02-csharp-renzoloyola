namespace Bank.WebApi.Models
{
    /// <summary>
    /// Representa una cuenta bancaria con operaciones básicas de débito y crédito.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        private BankAccount() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase BankAccount.
        /// </summary>
        /// <param name="customerName">Nombre del cliente.</param>
        /// <param name="balance">Saldo inicial de la cuenta.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Obtiene el nombre del cliente.
        /// </summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>
        /// Obtiene el saldo actual de la cuenta.
        /// </summary>
        public double Balance { get { return m_balance; } }

        /// <summary>
        /// Realiza un débito (retiro) de la cuenta.
        /// </summary>
        /// <param name="amount">Monto a debitar.</param>
        /// <exception cref="ArgumentOutOfRangeException">Se lanza cuando el monto es mayor al saldo o es negativo.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount");
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance -= amount;
        }

        /// <summary>
        /// Realiza un crédito (depósito) a la cuenta.
        /// </summary>
        /// <param name="amount">Monto a acreditar.</param>
        /// <exception cref="ArgumentOutOfRangeException">Se lanza cuando el monto es negativo.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}

