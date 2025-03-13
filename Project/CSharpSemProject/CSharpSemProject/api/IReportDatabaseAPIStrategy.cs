using System.Collections.Generic;

namespace CSharpSemProject.api
{
    interface IReportDatabaseAPIStrategy
    {
        ReportData GetReport(long reportId);
        ReportData CreateReport(long videoId, long userId, string description);
        ReportData EditReport(long reportId, string description);
        List<ReportData> GetReports();
    }
}
