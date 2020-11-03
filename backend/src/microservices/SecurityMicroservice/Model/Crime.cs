using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityMicroservice.Model
{
    public class Crime
    {
        public static readonly string DocumentName = "crimes";
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Natural { get; set; }
        public List<CrimeLocalization> ListCrimeLocalizations { get; set; }

    }
}
