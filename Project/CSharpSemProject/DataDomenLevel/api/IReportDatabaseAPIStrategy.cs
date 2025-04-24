using DataDomenLevel.data;
using System.Collections.Generic;

namespace DataDomenLevel.api
{
    public interface IReportDatabaseAPIStrategy
    {
        ReportData GetReport(long reportId);
        ReportData CreateReport(long videoId, long userId, string description);
        ReportData EditReport(long reportId, string description);
        List<ReportData> GetReports();
    }
}
