
using FinancialMicroservice.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinancialMicroservice.Repository
{
    public class IPTURepository : IIPTURepository
    {
        private readonly IMongoCollection<Taxpayer> _col;

        public IPTURepository(IMongoDatabase db)
        {
            _col = db.GetCollection<Taxpayer>(Taxpayer.DocumentName);
        }

  
        public List<IPTU> GetIPTUByTaxPayerId(Guid taxpayerId)
        {
            var taxpayer = _col.Find(c => c.Id == taxpayerId).FirstOrDefault();
            if (taxpayer != null)
            {
                return taxpayer.GetIPTUs;
            }
            return new List<IPTU>();
        }

        public void InsertIPTU(Taxpayer taxpayer, IPTU iptu)
        {
            var taxpayer1 = _col.Find(c => c.Id == taxpayer.Id).FirstOrDefault();
            if (taxpayer1 == null)
            {
                taxpayer1 = new Taxpayer { 
                    Id = taxpayer.Id, 
                    Document = taxpayer.Document,
                    Email = taxpayer.Email,
                    Name = taxpayer.Name,
                    GetIPTUs = new List<IPTU> { iptu } };
                _col.InsertOne(taxpayer);
            }
            else
            {
                var cartItemFromDb = taxpayer1.GetIPTUs.FirstOrDefault(ci => ci.Reference == iptu.Reference && ci.Validity == iptu.Validity);
                if (cartItemFromDb == null)
                {
                    taxpayer1.GetIPTUs.Add(iptu);
                }
               
                var update = Builders<Taxpayer>.Update
                   .Set(c => c.GetIPTUs, taxpayer1.GetIPTUs);
                _col.UpdateOne(c => c.Id == taxpayer.Id, update);
            }
        }

        public void UpdateIPTU(Guid taxpayerId, IPTU iptu)
        {
            var cart = _col.Find(c => c.Id == taxpayerId).FirstOrDefault();
            if (cart != null)
            {
                cart.GetIPTUs.RemoveAll(ci => ci.Reference == iptu.Reference && ci.Validity == iptu.Validity);
                cart.GetIPTUs.Add(iptu);
                var update = Builders<Taxpayer>.Update
                   .Set(c => c.GetIPTUs, cart.GetIPTUs);
                _col.UpdateOne(c => c.Id == taxpayerId, update);
            }
        }

        public void DeleteIPTU(Guid taxpayerId, IPTU iptu)
        {
            var cart = _col.Find(c => c.Id == taxpayerId).FirstOrDefault();
            if (cart != null)
            {
                cart.GetIPTUs.RemoveAll(ci => ci.Reference == iptu.Reference && ci.Validity == iptu.Validity);
                cart.GetIPTUs.Add(iptu);
                var update = Builders<Taxpayer>.Update
                   .Set(c => c.GetIPTUs, cart.GetIPTUs);
                _col.UpdateOne(c => c.Id == taxpayerId, update);
            }
        }
    }
}
