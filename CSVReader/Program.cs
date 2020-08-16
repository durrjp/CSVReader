using CsvHelper;
using CSVReader.models;
using CSVReader.repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string cn = @"data source=localhost\SQLEXPRESS; Database=ZipMarkets;integrated security = true";
            // Zips CSV reader
            /*using (var zipReader = new StreamReader("\\Users\\durrj\\Documents\\ZipMarkets\\CSV Files\\AllZipCodes.csv"))
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

            // Quick method of updating zipcode stateIds to match states tables
            /*AllZipsRepository allZipRepo = new AllZipsRepository(cn);
            StatesRepository stateRepo = new StatesRepository(cn);
            var allZips = allZipRepo.GetAll();
            var allStates = stateRepo.GetAll();
            foreach(Zip zip in allZips)
            {
                var foundState = allStates.FirstOrDefault(s => s.StateAbbr == zip.State);
                zip.StateId = foundState.Id;
                allZipRepo.Update(zip);
            }
            */


            //function to read zipcode lat and long and assign to current zip codes
            /*using (var zipLLReader = new StreamReader("\\Users\\durrj\\Documents\\ZipMarkets\\CSV Files\\USZipCodeLatLong.csv"))
            using (var zipLLCsv = new CsvReader(zipLLReader, CultureInfo.InvariantCulture))
            {
                zipLLCsv.Configuration.RegisterClassMap<ZipLatLongMap>();
                var zipLLRecords = zipLLCsv.GetRecords<ZipLatLong>().ToList();
                AllZipsRepository allZipRepo = new AllZipsRepository(cn);
                var allZips = allZipRepo.GetAll();
                foreach(Zip zip in allZips)
                {
                    var foundLatLong = zipLLRecords.FirstOrDefault(ll => ll.Zip == zip.ZipCode);
                    if (foundLatLong != null)
                    {
                        zip.Latitude = foundLatLong.Latitude;
                        zip.Longitude = foundLatLong.Longitude;
                        allZipRepo.Update(zip);
                    }
                    else
                    {
                        continue;
                    }
                }

            }*/


            // HPI CSV reader
            /*using (var hpiReader = new StreamReader("\\Users\\durrj\\Documents\\ZipMarkets\\CSV Files\\HPI5DigZipsRAW.csv"))
            using (var hpiCsv = new CsvReader(hpiReader, CultureInfo.InvariantCulture))
            {
                hpiCsv.Configuration.RegisterClassMap<HPIClassMap>();
                var hpiRecords = hpiCsv.GetRecords<HPIClass>();
                UploadRepository upLoadRepo = new UploadRepository(cn);
                AllZipsRepository allZipRepo = new AllZipsRepository(cn);
                var allZips = allZipRepo.GetAll();
                foreach (HPIClass hpi in hpiRecords)
                {
                    if (allZips.Any(z => z.ZipCode == hpi.ZipCode))
                    {
                        var foundZip = allZips.FirstOrDefault(z => z.ZipCode == hpi.ZipCode);
                        hpi.ZipCodeId = foundZip.Id;
                        upLoadRepo.Insert(hpi);
                    }
                }
            }*/

            //ZVHI CSV Reader

            /*using (var zvhiReader = new StreamReader("\\Users\\durrj\\Documents\\ZipMarkets\\CSV Files\\ZVHIRawEdited.csv"))
            using (var zvhiCsv = new CsvReader(zvhiReader, CultureInfo.InvariantCulture))
            {
                // Create a list of dates from the last 20 years using the last date supplied in csv document
                string lastDate = "6/30/2020";
                string[] lastDateArray = lastDate.Split('/');
                HashSet<string> allDates = new HashSet<string>();
                for (int i = 0; i < 20; i++)
                {
                    int year = Convert.ToInt32(lastDateArray[2]);
                    int newYear = year - i;
                    string newYearString = Convert.ToString(newYear);
                    allDates.Add(lastDateArray[0] + "/" + lastDateArray[1] + "/" + newYearString);
                }
                DateTime lastDateTime = Convert.ToDateTime(lastDate);

                // Get a list of dynamic records and convert dynamic class to list of Dictionaries
                var zvhiRecords = zvhiCsv.GetRecords<dynamic>().ToList();
                var json = JsonConvert.SerializeObject(zvhiRecords);
                var dictionaryList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
                var newDictionary = new List<Dictionary<string, string>>();

                // filter the new list of dictionaries by the list of allDates needed above
                foreach (Dictionary<string, string> listItem in dictionaryList)
                {
                    var filter = listItem
                        .Where(lI => lI.Key == "ZipCode" || allDates.Contains(lI.Key))
                        .ToDictionary(lI => lI.Key, lI => lI.Value);
                    newDictionary.Add(filter);
                }
                var importList = new List<ZVHI>();
                AllZVHIsRepository allZVHIRepo = new AllZVHIsRepository(cn);
                AllZipsRepository allZipRepo = new AllZipsRepository(cn);
                var allZips = allZipRepo.GetAll();
                // iterate through each dictionary in list of dictionaries
                foreach (Dictionary<string, string> dictionary in newDictionary)
                {
                    // convert the ZipCode value from csv to an integer
                    int dictionaryZip = Convert.ToInt32(dictionary["ZipCode"]);

                    // see if any of current zips in database match zvhi entry in question
                    if (allZips.Any(z => z.ZipCode == dictionaryZip))
                    {
                        var foundZip = allZips.FirstOrDefault(z => z.ZipCode == dictionaryZip);
                        // if they do match, then iterate over all key value pairs in dictionary
                        foreach(KeyValuePair<string, string> entry in dictionary)
                        {
                            if(entry.Key != "ZipCode")
                            {
                                try
                                {
                                    var newZVHI = new ZVHI()
                                    {
                                        ZipCodeId = foundZip.Id,
                                        Date = Convert.ToDateTime(entry.Key),
                                        Value = Convert.ToInt32(entry.Value)
                                    };
                                    allZVHIRepo.Insert(newZVHI);
                                }
                                catch
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }*/

            // States CSV Reader
            /*using (var stateReader = new StreamReader("\\Users\\durrj\\Documents\\ZipMarkets\\CSV Files\\StateCostofLivingIndexes.csv"))
            using (var stateCsv = new CsvReader(stateReader, CultureInfo.InvariantCulture))
            {
                stateCsv.Configuration.RegisterClassMap<StateClassMap>();
                var stateRecords = stateCsv.GetRecords<State>();
                StatesRepository stateRepo = new StatesRepository(cn);
                foreach (State state in stateRecords)
                {
                    stateRepo.Insert(state);
                }
            }*/

            // Mortgage rates CSV Reader
        }
    }
}
