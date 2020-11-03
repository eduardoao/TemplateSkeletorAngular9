using CatalogMicroservice.Repository;
using SecurityMicroservice.Model;
using System;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;

namespace SecurityMicroservice.Repository
{
    public class CrimeRepository : ICrimeRepository
    {
        private readonly IMongoCollection<Crime> _col;

        public CrimeRepository(IMongoDatabase db)
        {
            _col = db.GetCollection<Crime>(Crime.DocumentName);
        }

        public List<Crime> GetAllCrime()
        {
           return _col.Find(FilterDefinition<Crime>.Empty).ToList();
        }

        public Crime GetCrime(Guid crimeId)
        {
            var crime = _col.Find(c => c.Id == crimeId).FirstOrDefault();
            if (crime != null)
            {
                return crime;
            }
            return  null;
        }

        public List<CrimeLocalization> GetListCrimeLocalization(Guid crimeId)
        {
            var crime = _col.Find(c => c.Id == crimeId).FirstOrDefault();
            if (crime != null)
            {
                return crime.ListCrimeLocalizations;
            }
            return new List<CrimeLocalization>();
        }

        public void InsertCrime(Guid crimeId, Crime crimeItem)
        {
            var crime = _col.Find(c => c.Id == crimeId).FirstOrDefault();
            if (crime == null)
            {
                crime = new Crime { Id = Guid.NewGuid(), Natural = crimeItem.Natural, Year= crimeItem.Year, ListCrimeLocalizations = new List<CrimeLocalization>(crimeItem.ListCrimeLocalizations) };
                _col.InsertOne(crime);
            }
            else
            {
                var cartItemFromDb = crime.ListCrimeLocalizations.FirstOrDefault(ci => ci.Id == crimeItem.ListCrimeLocalizations[0].Id);
                if (cartItemFromDb == null)
                {
                    crime.ListCrimeLocalizations.Add(crimeItem.ListCrimeLocalizations[0]);
                }
                else
                {
                    cartItemFromDb.Quantity = cartItemFromDb.Quantity + crimeItem.ListCrimeLocalizations[0].Quantity;
                }
                var update = Builders<Crime>.Update
                   .Set(c => c.ListCrimeLocalizations, crime.ListCrimeLocalizations);
                _col.UpdateOne(c => c.Id == crimeId, update);
            }
        }

        public void InsertCrimeLocalizationItem(Guid crimeId, CrimeLocalization crimeLocalization)
        {
            var crime = _col.Find(c => c.Id == crimeId).FirstOrDefault();
            if (crime == null)
            {
                crime = new Crime { Id = crimeId, ListCrimeLocalizations = new List<CrimeLocalization> { crimeLocalization } };
                _col.InsertOne(crime);
            }
            else
            {
                var cartItemFromDb = crime.ListCrimeLocalizations.FirstOrDefault(ci => ci.Id == crimeLocalization.Id);
                if (cartItemFromDb == null)
                {
                    crime.ListCrimeLocalizations.Add(crimeLocalization);
                }
                else
                {
                    cartItemFromDb.Quantity = cartItemFromDb.Quantity + crimeLocalization.Quantity;
                }
                var update = Builders<Crime>.Update
                   .Set(c => c.ListCrimeLocalizations, crime.ListCrimeLocalizations);
                _col.UpdateOne(c => c.Id == crimeId, update);
            }
        }

        public void UpdateCrimeLocalizationItem(Guid crimeId, CrimeLocalization catalogItem)
        {
            var cart = _col.Find(c => c.Id == crimeId).FirstOrDefault();
            if (cart != null)
            {
                cart.ListCrimeLocalizations.RemoveAll(ci => ci.Id == catalogItem.Id);
                cart.ListCrimeLocalizations.Add(catalogItem);
                var update = Builders<Crime>.Update
                   .Set(c => c.ListCrimeLocalizations, cart.ListCrimeLocalizations);
                _col.UpdateOne(c => c.Id == crimeId, update);
            }

        }

        public void DeleteCrimeLocalizationItem(Guid crimeId, Guid crimeLocalizationId)
        {
            var cart = _col.Find(c => c.Id == crimeId).FirstOrDefault();
            if (cart != null)
            {
                cart.ListCrimeLocalizations.RemoveAll(ci => ci.Id == crimeId);
                var update = Builders<Crime>.Update
                   .Set(c => c.ListCrimeLocalizations, cart.ListCrimeLocalizations);
                _col.UpdateOne(c => c.Id == crimeId, update);
            }

        }

    
    }
}
