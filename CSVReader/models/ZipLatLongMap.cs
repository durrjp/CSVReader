using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSVReader.models
{
    public class ZipLatLongMap: ClassMap<ZipLatLong>
    {
        public ZipLatLongMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
