using System;
using System.Collections.Generic;

namespace RevenueReport.ModelsGenerated
{
    public partial class ContainerType
    {
        public ContainerType()
        {
            InvoiceDtl = new HashSet<InvoiceDtl>();
        }

        public int ContainerTypeAutoId { get; set; }
        public string ContainerTypeId { get; set; }
        public string ContainerCommonName { get; set; }
        public string IsoCode { get; set; }
        public string NewIsoCode { get; set; }
        public decimal? WeightLimit { get; set; }
        public int EbmsTenantAutoId { get; set; }
        public Guid UniqueId { get; set; }
        public string Ngstatus { get; set; }

        public virtual ICollection<InvoiceDtl> InvoiceDtl { get; set; }
    }
}
