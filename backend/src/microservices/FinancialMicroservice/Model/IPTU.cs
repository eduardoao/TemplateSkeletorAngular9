using System;

namespace FinancialMicroservice.Model
{
    public class IPTU
    {
        
        public int Reference { get; set; }
        public string Document { get; set; }
        public int Quota { get; set; }
        public double Principal { get; set; }
        public double Fine { get; set; }
        public string Status { get; set; }
        public DateTime Validity { get; set; }
        public string  Address { get; set; }       

    }
}
