using System;
using System.Collections.Generic;

namespace FinancialMicroservice.Model
{
    public class Taxpayer
    {
        public static readonly string DocumentName = "taxpayers";
        public Guid Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<IPTU> GetIPTUs { get; set; }
    }
}
