using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader.models
{
    public class State
    {
        public int Id { get; set; }
        public string StateAbbr { get; set; }
        public string StateName { get; set; }
        public decimal costIndex { get; set; }
        public int costRank { get; set; }
        public decimal groceryCost { get; set; }
        public decimal housingCost { get; set; }
        public decimal utilitiesCost { get; set; }
        public decimal transportationCost { get; set; }
        public decimal miscCost { get; set; }
    }
}
