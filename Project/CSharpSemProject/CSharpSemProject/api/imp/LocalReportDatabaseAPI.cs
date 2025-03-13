using System;

namespace CSharpSemProject.api.impl
{
    class LocalReportDatabaseAPI : IReportDatabaseAPIStrategy
    {
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
    }
}
