using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSVReader.models
{
    public sealed class HPIClassMap : ClassMap<HPIClass>
    {
        public HPIClassMap()
        {
            Map(m => m.ZipCode);
            Map(m => m.Year);
            Map(m => m.HPI);
        }
    }
}
