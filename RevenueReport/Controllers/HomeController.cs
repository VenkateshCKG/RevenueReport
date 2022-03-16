using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using RevenueReport.Models;
using RevenueReport.ModelsGenerated;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace RevenueReport.Controllers
{
    public class FooViewModel
    {
        [DisplayName("Form Date")]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime Todate { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FamilyTreeContext _context;

        public HomeController(FamilyTreeContext dbContext, ILogger<HomeController> logger)
        {
            _context = dbContext;
        }


        [HttpPost]
        public ActionResult Search(string fromdate, string todate)
        {
           
            DateTime fromDate;
            DateTime toDate;

            if (DateTime.TryParse(fromdate, out fromDate) && DateTime.TryParse(todate, out toDate))
            {
                String.Format("{0:d/MM/yyyy}", fromDate);
                String.Format("{0:d/MM/yyyy}", toDate);
            }
            else
            {
                return Content("Invalid Form or To Date");
            }

            var table = _context.InvoiceHdr
           .Join(
           _context.InvoiceDtl,
           invoiceHdr => invoiceHdr.InvoiceHdrAutoId,
           invoiceDtl => invoiceDtl.InvoiceHdrAutoId,
           (invoiceHdr, invoiceDtl) => new
           {
               InvoiceNo = invoiceHdr.GeneratedId,
               InvoiceDate = invoiceHdr.InvoiceDt,
               CustomerName = invoiceHdr.InvoiceTo,
               Key = invoiceDtl.ChargePrintDisName,
               Value = invoiceDtl.BaseCurrencyAmt
           }).Where( a => a.InvoiceDate >= fromDate.Date && a.InvoiceDate <= toDate).ToList();

            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "Key";

            DataColumn dataColumn1 = new DataColumn();
            dataColumn1.ColumnName = "Value";

            DataTable report = ToDataTable(table);
            DataTable test = Pivot(report, dataColumn, dataColumn1);

            test.Columns.Add("Total Amount");

            foreach (DataRow row in test.Rows)
            {
                decimal rowTotal = 0;
                foreach (DataColumn col in row.Table.Columns)
                {
                    decimal n;
                    bool isNumeric = decimal.TryParse(Convert.ToString(row[col]), out n);
                    Console.WriteLine(row[col]);
                    if (isNumeric)
                    {
                        rowTotal += decimal.Parse(row[col].ToString());
                    }
                }
                row["Total Amount"] = rowTotal;
            }

            return View("Index", test);
        }
        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
                .Select(r => r[pivotColumn.ColumnName].ToString())
                .Distinct().ToList()
                .ForEach(c => result.Columns.Add(c, pivotValue.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                    pkColumnNames
                        .Select(c => row[c])
                        .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];
            }

            return result;
        }
        public IActionResult Index()
        {



            var table = _context.InvoiceHdr
           .Join(
           _context.InvoiceDtl,
           invoiceHdr => invoiceHdr.InvoiceHdrAutoId,
           invoiceDtl => invoiceDtl.InvoiceHdrAutoId,
           (invoiceHdr, invoiceDtl) => new
           {
               InvoiceNo = invoiceHdr.GeneratedId,
               InvoiceDate = invoiceHdr.InvoiceDt,
               CustomerName = invoiceHdr.InvoiceTo,
               Key = invoiceDtl.ChargePrintDisName,
               Value = invoiceDtl.BaseCurrencyAmt
           }).Take(10).ToList();

            DataColumn dataColumn = new DataColumn();
            dataColumn.ColumnName = "Key";

            DataColumn dataColumn1 = new DataColumn();
            dataColumn1.ColumnName = "Value";

            DataTable report = ToDataTable(table);
            DataTable test = Pivot(report, dataColumn, dataColumn1);

            test.Columns.Add("Total Amount");

            foreach (DataRow row in test.Rows)
            {
                decimal rowTotal = 0;
                foreach (DataColumn col in row.Table.Columns)
                {
                    decimal n;
                    bool isNumeric = decimal.TryParse(Convert.ToString(row[col]), out n);
                    Console.WriteLine(row[col]);
                    if (isNumeric)
                    {
                        rowTotal += decimal.Parse(row[col].ToString());
                    }
                }
                row["Total Amount"] = rowTotal;
            }

            return View(test);
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
