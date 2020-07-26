using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.models
{
    public sealed class ZVHIClassMap: ClassMap<ZVHI>
    {
        public ZVHIClassMap()
        {
            Map(m => m.ZipCode);
            Map(m => m.ZipCode);
            Map(m => m.ZipCode);
        }
    }
}
