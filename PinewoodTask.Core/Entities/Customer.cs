using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Core.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? PostCode { get; set; }
        public string? City { get; set; }
        public string? Conty { get; set; }
        public string? Country { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}

