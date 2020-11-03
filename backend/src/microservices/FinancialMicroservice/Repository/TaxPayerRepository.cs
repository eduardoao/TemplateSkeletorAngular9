
using FinancialMicroservice.Model;
using MongoDB.Driver;
using System;

using System.Linq;

namespace FinancialMicroservice.Repository
{
    public class TaxPayerRepository : ITaxPayerRepository
    {
        private readonly IMongoCollection<Taxpayer> _col;

        public TaxPayerRepository(IMongoDatabase db)
        {
            _col = db.GetCollection<Taxpayer>(Taxpayer.DocumentName);
        }

    

        public Taxpayer GetTaxpayer(Guid taxpayerId)
        {
            var taxpayer = _col.Find(c => c.Id == taxpayerId).FirstOrDefault();
            if (taxpayer != null)
            {
                return taxpayer;
            }
            return new Taxpayer();
        }
    }
}
