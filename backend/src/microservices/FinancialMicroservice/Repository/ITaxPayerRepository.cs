
using FinancialMicroservice.Model;
using System;


namespace FinancialMicroservice.Repository
{
    public interface ITaxPayerRepository
    {
        Taxpayer GetTaxpayer(Guid TaxpayerId);
      
    }
}
