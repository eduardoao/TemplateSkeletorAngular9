
using FinancialMicroservice.Model;
using System;
using System.Collections.Generic;

namespace FinancialMicroservice.Repository
{
    public interface IIPTURepository
    {
        List<IPTU> GetIPTUByTaxPayerId(Guid TaxpayerId);
        void InsertIPTU(Taxpayer taxpayerId, IPTU iptu);
        void UpdateIPTU(Guid TaxpayerId, IPTU iptu);
        void DeleteIPTU(Guid TaxpayerId, IPTU iptu);
    }
}
