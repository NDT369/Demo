using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment3_PRN211.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
    }
}
