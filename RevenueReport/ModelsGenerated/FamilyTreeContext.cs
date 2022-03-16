using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RevenueReport.ModelsGenerated
{
    public partial class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext()
        {
        }

        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChargeMaster> ChargeMaster { get; set; }
        public virtual DbSet<ContainerType> ContainerType { get; set; }
        public virtual DbSet<CountryMaster> CountryMaster { get; set; }
        public virtual DbSet<CurrencyMaster> CurrencyMaster { get; set; }
        public virtual DbSet<InvoiceDtl> InvoiceDtl { get; set; }
        public virtual DbSet<InvoiceHdr> InvoiceHdr { get; set; }
        public virtual DbSet<InvoiceTaxDtl> InvoiceTaxDtl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=ebmsngdev13.postgres.database.azure.com;Database=GGEODEval;User Id=GGEODEval;Password=GG(0DEv@L;Port=5432");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("tablefunc")
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ChargeMaster>(entity =>
            {
                entity.HasKey(e => e.ChargeMasterAutoId)
                    .HasName("ChargeMaster_pkey");

                entity.ToTable("ChargeMaster", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("ChargeMaster_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.ChargeMasterAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"ChargeMaster_ChargeMasterAutoId_seq\"'::regclass)");

                entity.Property(e => e.ChargeCode).HasMaxLength(10);

                entity.Property(e => e.ChargeName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");
            });

            modelBuilder.Entity<ContainerType>(entity =>
            {
                entity.HasKey(e => e.ContainerTypeAutoId)
                    .HasName("ContainerType_pkey");

                entity.ToTable("ContainerType", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("ContainerType_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.ContainerTypeAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"ContainerType_ContainerTypeAutoId_seq\"'::regclass)");

                entity.Property(e => e.ContainerCommonName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContainerTypeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsoCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.NewIsoCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.WeightLimit).HasColumnType("numeric(28,8)");
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.HasKey(e => e.CountryMasterAutoId)
                    .HasName("CountryMaster_pkey");

                entity.ToTable("CountryMaster", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("CountryMaster_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.CountryMasterAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"CountryMaster_CountryMasterAutoId_seq\"'::regclass)");

                entity.Property(e => e.CapitalName).HasMaxLength(30);

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsGcc).HasColumnName("IsGCC");

                entity.Property(e => e.Iso3code)
                    .HasColumnName("ISO3Code")
                    .HasMaxLength(3);

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.PhonePrefix).HasMaxLength(27);

                entity.Property(e => e.StateLabel).HasMaxLength(20);

                entity.Property(e => e.TaxType).HasMaxLength(16);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");
            });

            modelBuilder.Entity<CurrencyMaster>(entity =>
            {
                entity.HasKey(e => e.CurrencyMasterAutoId)
                    .HasName("CurrencyMaster_pkey");

                entity.ToTable("CurrencyMaster", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("CurrencyMaster_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.CurrencyMasterAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"CurrencyMaster_CurrencyMasterAutoId_seq\"'::regclass)");

                entity.Property(e => e.CurrencyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyName).HasMaxLength(30);

                entity.Property(e => e.CurrencyStyle).HasMaxLength(20);

                entity.Property(e => e.CurrencySymbol).HasMaxLength(10);

                entity.Property(e => e.DecimalName).HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.CountryMasterAuto)
                    .WithMany(p => p.CurrencyMaster)
                    .HasForeignKey(d => d.CountryMasterAutoId)
                    .HasConstraintName("FK_Currency_Country");
            });

            modelBuilder.Entity<InvoiceDtl>(entity =>
            {
                entity.HasKey(e => e.InvoiceDtlAutoId)
                    .HasName("InvoiceDtl_pkey");

                entity.ToTable("InvoiceDtl", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("InvoiceDtl_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.InvoiceDtlAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"InvoiceDtl_InvoiceDtlAutoId_seq\"'::regclass)");

                entity.Property(e => e.BaseCurrAmountWithTax).HasColumnType("numeric(28,8)");

                entity.Property(e => e.BaseCurrencyAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.BaseCurrencyTaxableAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.ChargePrintDisName).HasMaxLength(500);

                entity.Property(e => e.ExchangeRate).HasColumnType("numeric(28,8)");

                entity.Property(e => e.LastModifiedNature).HasMaxLength(64);

                entity.Property(e => e.LastUpdateDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.Qty).HasColumnType("numeric(28,8)");

                entity.Property(e => e.Rate).HasColumnType("numeric(28,8)");

                entity.Property(e => e.Saccode)
                    .HasColumnName("SACCode")
                    .HasMaxLength(20);

                entity.Property(e => e.TaxCode).HasMaxLength(8);

                entity.Property(e => e.TranCurrAmountWithTax).HasColumnType("numeric(28,8)");

                entity.Property(e => e.TranCurrencyAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.TranCurrencyTaxableAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.ChargeMasterAuto)
                    .WithMany(p => p.InvoiceDtl)
                    .HasForeignKey(d => d.ChargeMasterAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceDtl_ChargeMasterAutoId_fkey");

                entity.HasOne(d => d.ContainerTypeAuto)
                    .WithMany(p => p.InvoiceDtl)
                    .HasForeignKey(d => d.ContainerTypeAutoId)
                    .HasConstraintName("InvoiceDtl_ContainerTypeAutoId_fkey");

                entity.HasOne(d => d.CurrencyMasterAuto)
                    .WithMany(p => p.InvoiceDtl)
                    .HasForeignKey(d => d.CurrencyMasterAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceDtl_CurrencyMasterAutoId_fkey");

                entity.HasOne(d => d.RefInvoiceDtlAuto)
                    .WithMany(p => p.InverseRefInvoiceDtlAuto)
                    .HasForeignKey(d => d.RefInvoiceDtlAutoId)
                    .HasConstraintName("InvoiceDtl_RefInvoiceDtlAutoId_fkey");
            });

            modelBuilder.Entity<InvoiceHdr>(entity =>
            {
                entity.HasKey(e => e.InvoiceHdrAutoId)
                    .HasName("InvoiceHdr_pkey");

                entity.ToTable("InvoiceHdr", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("InvoiceHdr_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.InvoiceHdrAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"InvoiceHdr_InvoiceHdrAutoId_seq\"'::regclass)");

                entity.Property(e => e.BaseCurrAmtInWords).HasMaxLength(500);

                entity.Property(e => e.BaseCurrencyAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.ExternalInvDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.ExternalInvNo).HasMaxLength(50);

                entity.Property(e => e.GeneratedId).HasMaxLength(96);

                entity.Property(e => e.Gstno)
                    .HasColumnName("GSTNo")
                    .HasMaxLength(32);

                entity.Property(e => e.GsttaxInvType)
                    .HasColumnName("GSTTaxInvType")
                    .HasMaxLength(16);

                entity.Property(e => e.InvoiceDt).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.InvoiceExchangeRate)
                    .HasColumnType("numeric(28,8)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.InvoiceStatus).HasMaxLength(15);

                entity.Property(e => e.InvoiceTo).HasMaxLength(100);

                entity.Property(e => e.InvoiceType).HasMaxLength(16);

                entity.Property(e => e.IsLut).HasColumnName("IsLUT");

                entity.Property(e => e.Isrcmapplicable).HasColumnName("ISRCMApplicable");

                entity.Property(e => e.JobcardId).HasMaxLength(30);

                entity.Property(e => e.LastModifiedNature).HasMaxLength(64);

                entity.Property(e => e.LastUpdateDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Lutnumber)
                    .HasColumnName("LUTNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.PartyGstType).HasColumnType("character varying");

                entity.Property(e => e.RawPrefix).HasMaxLength(64);

                entity.Property(e => e.Rcmtype)
                    .HasColumnName("RCMType")
                    .HasColumnType("character varying");

                entity.Property(e => e.ReasonsForCreditNote).HasMaxLength(512);

                entity.Property(e => e.ScndCurrAmtInWords).HasMaxLength(512);

                entity.Property(e => e.ScndCurrencyAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.SecondaryExchangeRate).HasColumnType("numeric(28,8)");

                entity.Property(e => e.Sezflag).HasColumnName("SEZFlag");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'DR'::character varying");

                entity.Property(e => e.TaxInvoiceType).HasMaxLength(16);

                entity.Property(e => e.TaxType).HasColumnType("character varying");

                entity.Property(e => e.TranCurrAmtInWords).HasMaxLength(512);

                entity.Property(e => e.TranCurrencyAmt).HasColumnType("numeric(28,8)");

                entity.Property(e => e.Type).HasMaxLength(15);

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.InvoiceCurrencyAuto)
                    .WithMany(p => p.InvoiceHdrInvoiceCurrencyAuto)
                    .HasForeignKey(d => d.InvoiceCurrencyAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceCurrencyAutoId_InvoiceHdr_CurrencyMAster");

                entity.HasOne(d => d.RefInvoiceHdrAuto)
                    .WithMany(p => p.InverseRefInvoiceHdrAuto)
                    .HasForeignKey(d => d.RefInvoiceHdrAutoId)
                    .HasConstraintName("InvoiceHdr_RefInvoiceHdrAutoId_fkey");

                entity.HasOne(d => d.SecondaryCurrencyAuto)
                    .WithMany(p => p.InvoiceHdrSecondaryCurrencyAuto)
                    .HasForeignKey(d => d.SecondaryCurrencyAutoId)
                    .HasConstraintName("InvoiceHdr_SecondaryCurrencyAutoId_fkey");
            });

            modelBuilder.Entity<InvoiceTaxDtl>(entity =>
            {
                entity.HasKey(e => e.InvoiceTaxDtlAutoId)
                    .HasName("InvoiceTaxDtl_pkey");

                entity.ToTable("InvoiceTaxDtl", "Accounts");

                entity.HasIndex(e => e.UniqueId)
                    .HasName("InvoiceTaxDtl_UniqueId_key")
                    .IsUnique();

                entity.Property(e => e.InvoiceTaxDtlAutoId).HasDefaultValueSql("nextval('\"Accounts\".\"InvoiceTaxDtl_InvoiceTaxDtlAutoId_seq\"'::regclass)");

                entity.Property(e => e.AppliedTaxRate).HasColumnType("numeric(28,8)");

                entity.Property(e => e.BaseCurrTaxAmount).HasColumnType("numeric(28,8)");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.LastModifiedNature).HasMaxLength(64);

                entity.Property(e => e.LastUpdateDate).HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Ngstatus)
                    .IsRequired()
                    .HasColumnName("NGStatus")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("'A'::character varying");

                entity.Property(e => e.TaxType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TranCurrTaxAmount).HasColumnType("numeric(28,8)");

                entity.Property(e => e.UniqueId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.ChargeMasterAuto)
                    .WithMany(p => p.InvoiceTaxDtl)
                    .HasForeignKey(d => d.ChargeMasterAutoId)
                    .HasConstraintName("InvoiceTaxDtl_ChargeMasterAutoId_fkey");

                entity.HasOne(d => d.InvoiceDtlAuto)
                    .WithMany(p => p.InvoiceTaxDtl)
                    .HasForeignKey(d => d.InvoiceDtlAutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceTaxDtl_InvoiceDtlAutoId_fkey");
            });
        }
    }
}
