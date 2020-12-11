using Contracts_Payments.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts_Payments.Services
{
    class ContractServices
    {
        private IOnlinePaymentServices _onlinePaymentServices;

        public ContractServices(IOnlinePaymentServices onlinePaymentServices)
        {
            _onlinePaymentServices = onlinePaymentServices;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / months;
            for(int i = 1; i <= months; i++)
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentServices.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _onlinePaymentServices.Paymentfee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }

}
