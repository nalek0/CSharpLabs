using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.api
{
    class DatabaseAPIFacade
    {
        IAdministratorDatabaseAPIStrategy _administratorDatabaseAPIStrategy;
        IReportDatabaseAPIStrategy _reportDatabaseAPIStrategy;
        IUserDatabaseAPIStrategy _userDatabaseAPIStrategy;
        IVideoDatabaseAPIStrategy _videoDatabaseAPIStrategy;

        public DatabaseAPIFacade(
            IAdministratorDatabaseAPIStrategy administratorDatabaseAPIStrategy,
            IReportDatabaseAPIStrategy reportDatabaseAPIStrategy,
            IUserDatabaseAPIStrategy userDatabaseAPIStrategy,
            IVideoDatabaseAPIStrategy videoDatabaseAPIStrategy)
        {
            _administratorDatabaseAPIStrategy = administratorDatabaseAPIStrategy;
            _reportDatabaseAPIStrategy = reportDatabaseAPIStrategy;
            _userDatabaseAPIStrategy = userDatabaseAPIStrategy;
            _videoDatabaseAPIStrategy = videoDatabaseAPIStrategy;
        }

        AdministratorData GetAdministrator(long id)
        {
            return _administratorDatabaseAPIStrategy.GetAdministrator(id);
        }

        AdministratorData CreateAdministrator(string firstName, string lastName, string nickname)
        {
            return _administratorDatabaseAPIStrategy.CreateAdministrator(firstName, lastName, nickname);
        }

        AdministratorData RemoveAdministrator(long id)
        {
            return _administratorDatabaseAPIStrategy.RemoveAdministrator(id);
        }

        AdministratorData EditAdministrator(long id, string firstName, string lastName, string nickname)
        {
            return _administratorDatabaseAPIStrategy.EditAdministrator(id, firstName, lastName, nickname);
        }

        ReportData GetReport(long reportId)
        {
            return _reportDatabaseAPIStrategy.GetReport(reportId);
        }

        ReportData CreateReport(long videoId, long userId, string description)
        {
            return _reportDatabaseAPIStrategy.CreateReport(videoId, userId, description);
        }

        ReportData EditReport(long reportId, string description)
        {
            return _reportDatabaseAPIStrategy.EditReport(reportId, description);
        }

        UserData GetUser(long id)
        {
            return _userDatabaseAPIStrategy.GetUser(id);
        }

        UserData BanUser(long id)
        {
            return _userDatabaseAPIStrategy.BanUser(id);
        }

        VideoData GetVideo(long id)
        {
            return _videoDatabaseAPIStrategy.GetVideo(id);
        }

        VideoData BanVideo(long id)
        {
            return _videoDatabaseAPIStrategy.BanVideo(id);
        }
    }
}
