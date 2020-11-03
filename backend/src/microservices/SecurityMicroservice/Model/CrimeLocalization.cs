using System;

namespace SecurityMicroservice.Model
{
    public class CrimeLocalization
    {
        public static readonly string DocumentName = "crimeLocalization";

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
