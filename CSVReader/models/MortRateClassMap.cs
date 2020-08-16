using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSVReader.models
{
    public sealed class MortRateClassMap: ClassMap<MortgageRate>
    {
        public MortRateClassMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Id).Ignore();
        }
    }
}
