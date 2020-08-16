using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.models
{
    public class MortgageRate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
