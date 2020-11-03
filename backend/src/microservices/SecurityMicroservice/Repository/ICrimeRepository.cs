
using SecurityMicroservice.Model;
using System;
using System.Collections.Generic;

namespace CatalogMicroservice.Repository
{
    public interface ICrimeRepository
    {
        Crime GetCrime (Guid crimeId);

        List<Crime> GetAllCrime();

        List<CrimeLocalization> GetListCrimeLocalization(Guid crimeLocalizationItemId);
        void InsertCrime(Guid crimeId, Crime crime);
       
        void UpdateCrimeLocalizationItem(Guid crimeId,CrimeLocalization catalogItem);
        void DeleteCrimeLocalizationItem(Guid crimeId,Guid crimeLocalizationId);
    }
}
