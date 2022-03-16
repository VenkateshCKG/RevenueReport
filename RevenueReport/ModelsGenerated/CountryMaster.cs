using System;
using System.Collections.Generic;

namespace RevenueReport.ModelsGenerated
{
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            CurrencyMaster = new HashSet<CurrencyMaster>();
        }

        public int CountryMasterAutoId { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string Iso3code { get; set; }
        public string CapitalName { get; set; }
        public string PhonePrefix { get; set; }
        public string StateLabel { get; set; }
        public bool IsGcc { get; set; }
        public string TaxType { get; set; }
        public Guid? UniqueId { get; set; }
        public bool IsSaas { get; set; }
        public string Ngstatus { get; set; }

        public virtual ICollection<CurrencyMaster> CurrencyMaster { get; set; }
    }
}
