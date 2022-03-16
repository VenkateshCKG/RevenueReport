using System;
using System.Collections.Generic;

namespace RevenueReport.ModelsGenerated
{
    public partial class CurrencyMaster
    {
        public CurrencyMaster()
        {
            InvoiceDtl = new HashSet<InvoiceDtl>();
            InvoiceHdrInvoiceCurrencyAuto = new HashSet<InvoiceHdr>();
            InvoiceHdrSecondaryCurrencyAuto = new HashSet<InvoiceHdr>();
        }

        public int CurrencyMasterAutoId { get; set; }
        public string CurrencyId { get; set; }
        public string Description { get; set; }
        public string DecimalName { get; set; }
        public int? CountryMasterAutoId { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyName { get; set; }
        public short? SubDivision { get; set; }
        public short? CurrencyDecimal { get; set; }
        public string CurrencyStyle { get; set; }
        public Guid? UniqueId { get; set; }
        public string Ngstatus { get; set; }

        public virtual CountryMaster CountryMasterAuto { get; set; }
        public virtual ICollection<InvoiceDtl> InvoiceDtl { get; set; }
        public virtual ICollection<InvoiceHdr> InvoiceHdrInvoiceCurrencyAuto { get; set; }
        public virtual ICollection<InvoiceHdr> InvoiceHdrSecondaryCurrencyAuto { get; set; }
    }
}
