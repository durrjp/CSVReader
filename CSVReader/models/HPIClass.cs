using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.models
{
    public class HPIClass
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public int Year { get; set; }
        public decimal HPI { get; set; }
        public int ZipCodeId { get; set; }
        public Zip Zip { get; set; }
    }
}
