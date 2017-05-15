using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Code
{
    public class Report
    {
        public static IEnumerable<MonthReportModel> ListAll()
        {
            return new MonthReportModel[] {
                new MonthReportModel { Month =  "June", Amount = 101 },
                new MonthReportModel { Month = "September", Amount = 20},
                new MonthReportModel{ Month = "October", Amount = 200}
            };
        }
    }
}
