using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts_Payments.Services
{
    interface IOnlinePaymentServices
    {
        double Paymentfee(double amount);
        double Interest(double amount, int months);
    }
}
