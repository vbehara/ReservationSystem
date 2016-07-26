using System;

namespace RailwayReservation
{
    /// <summary>
    /// Delegate to invoke the Purchase Tickets and Cancel Tickets methods
    /// </summary>
    /// <param name="creditCardNumber">Customer's Credit Card Number</param>
    /// <param name="amount">Ticket Amount</param>
    /// <returns></returns>

    public delegate bool MoneyTransaction(long creditCardNumber, double amount);

    /// <summary>
    /// This class maintains the transactions made by customer
    /// </summary>
    public class PaymentGateway
    {
        /// <summary>
        /// Accepts the Credit Card Number and Amount to purchase the ticket
        /// </summary>
        /// <param name="creditCardNumber">Customer's Credit Card Number</param>
        /// <param name="amount">Amount to be paid for the ticket</param>
        /// <returns></returns>
        public bool PurchaseTickets(long creditCardNumber,double amount)
        {
            Console.WriteLine("\nAmount {0} RS is debited from your account",amount);
            return false;
        }

        /// <summary>
        /// Accepts the Credit Card Number and Amount to cancel the ticket
        /// </summary>
        /// <param name="creditCardNumber">Customer's Credit Card Number</param>
        /// <param name="amount">Amount paid for the ticket</param>
        /// <returns>Returns a boolean value on success or failure</returns>
        public bool CancelTickets(long creditCardNumber,double amount)
        {
            Console.WriteLine("\nAmount {0} RS will be credited to your account",amount);
            return false;
        }
    }
}
