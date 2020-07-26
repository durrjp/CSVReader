using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.models
{
    public class ZVHI
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public int ZipCodeId { get; set; }
        public Zip Zip { get; set; }
    }
}
