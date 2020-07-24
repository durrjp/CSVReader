using CsvHelper;
using CSVReader.models;
using CSVReader.repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string cn = @"data source=localhost\SQLEXPRESS; Database=Neighborhoods;integrated security = true";
            // Zips CSV reader
            /*using (var zipReader = new StreamReader("\\Users\\durrj\\Documents\\HPITracker\\AllZipCodes.csv"))
            using (var zipCsv = new CsvReader(zipReader, CultureInfo.InvariantCulture))
            {
                zipCsv.Configuration.RegisterClassMap<ZipClassMap>();
                var zipRecords = zipCsv.GetRecords<Zip>();
                AllZipsRepository allZipRepo = new AllZipsRepository(cn);
                foreach (Zip zip in zipRecords)
                {
                    allZipRepo.Insert(zip);
                }
            }*/


            // HPI CSV reader
            using (var hpiReader = new StreamReader("\\Users\\durrj\\Documents\\HPITracker\\HPI5DigZipsRAW.csv"))
            using (var hpiCsv = new CsvReader(hpiReader, CultureInfo.InvariantCulture))
            {
                hpiCsv.Configuration.RegisterClassMap<HPIClassMap>();
                var hpiRecords = hpiCsv.GetRecords<HPIClass>();
                UploadRepository upLoadRepo = new UploadRepository(cn);
                AllZipsRepository allZipRepo = new AllZipsRepository(cn);
                var allZips = allZipRepo.GetAll();
                foreach (HPIClass hpi in hpiRecords)
                {
                    if(allZips.Any(z => z.ZipCode == hpi.ZipCode))
                    {
                        var foundZip = allZips.FirstOrDefault(z => z.ZipCode == hpi.ZipCode);
                        hpi.ZipCodeId = foundZip.Id;
                        upLoadRepo.Insert(hpi);
                    }
                }
            }



        }
    }
}
