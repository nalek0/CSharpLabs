using DataDomenLevel.data;
using DataDomenLevel.api;
using System;
using System.Collections.Generic;

namespace DataAccessLevel.api
{
    public class LocalReportDatabaseAPI : IReportDatabaseAPIStrategy
    {
        private List<ReportData> _reports = new List<ReportData>()
        {
            new ReportData() { ReportId = 1, UserId = 1, VideoId = 1, Description = "...", Status = ReportStatus.OPEN },
            new ReportData() { ReportId = 2, UserId = 2, VideoId = 2, Description = "...", Status = ReportStatus.OPEN }
        };

        public ReportData GetReport(long reportId)
        {
            throw new NotImplementedException();
        }
        
        public ReportData CreateReport(long videoId, long userId, string description)
        {
            throw new NotImplementedException();
        }

        public ReportData EditReport(long reportId, string description)
        {
            throw new NotImplementedException();
        }

        public List<ReportData> GetReports()
        {
            return _reports;
        }
    }
}
