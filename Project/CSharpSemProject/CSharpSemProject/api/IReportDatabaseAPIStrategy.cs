using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.api
{
    interface IReportDatabaseAPIStrategy
    {
        ReportData GetReport(long reportId);
        ReportData CreateReport(long videoId, long userId, string description);
        ReportData EditReport(long reportId, string description);
    }
}
