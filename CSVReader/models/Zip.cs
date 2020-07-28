using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.models
{
    public class Zip
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        public int StateId { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public Decimal ForecastYoYPctChange { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
    }
}
