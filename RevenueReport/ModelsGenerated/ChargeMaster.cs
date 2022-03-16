using System;
using System.Collections.Generic;

namespace RevenueReport.ModelsGenerated
{
    public partial class ChargeMaster
    {
        public ChargeMaster()
        {
            InvoiceDtl = new HashSet<InvoiceDtl>();
            InvoiceTaxDtl = new HashSet<InvoiceTaxDtl>();
        }

        public int ChargeMasterAutoId { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeName { get; set; }
        public int? CurrencyMasterAutoId { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid? UniqueId { get; set; }
        public string Ngstatus { get; set; }

        public virtual ICollection<InvoiceDtl> InvoiceDtl { get; set; }
        public virtual ICollection<InvoiceTaxDtl> InvoiceTaxDtl { get; set; }
    }
}
