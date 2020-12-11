using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts_Payments.Services
{
    class PayPalServices : IOnlinePaymentServices
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;
        public double Interest(double amount, int months)
        {
            return amount * MonthlyInterest * months;
        }

        public double Paymentfee(double amount)
        {
           return amount * FeePercentage;
        }
    }
}
