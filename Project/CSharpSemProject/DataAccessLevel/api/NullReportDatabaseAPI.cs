﻿using DataDomenLevel.data;
using DataDomenLevel.api;
using System.Collections.Generic;

namespace DataAccessLevel.api
{
    public class NullReportDatabaseAPI : IReportDatabaseAPIStrategy
    {
        public ReportData CreateReport(long videoId, long userId, string description)
        {
            throw new System.NotImplementedException();
        }

        public ReportData EditReport(long reportId, string description)
        {
            throw new System.NotImplementedException();
        }

        public ReportData GetReport(long reportId)
        {
            throw new System.NotImplementedException();
        }

        public List<ReportData> GetReports()
        {
            throw new System.NotImplementedException();
        }
    }
}
