using DataDomenLevel.data;
using DataDomenLevel.api;
using System.Collections.Generic;
using System;

namespace DataAccessLevel.api
{
    public class DatabaseAPIFacade : IDatabaseAPIFacade
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
            if (administratorDatabaseAPIStrategy == null)
                throw new ArgumentNullException("administratorDatabaseAPIStrategy");
            if (reportDatabaseAPIStrategy == null)
                throw new ArgumentNullException("reportDatabaseAPIStrategy");
            if (userDatabaseAPIStrategy == null)
                throw new ArgumentNullException("userDatabaseAPIStrategy");
            if (videoDatabaseAPIStrategy == null)
                throw new ArgumentNullException("videoDatabaseAPIStrategy");

            this._administratorDatabaseAPIStrategy = administratorDatabaseAPIStrategy;
            this._reportDatabaseAPIStrategy = reportDatabaseAPIStrategy;
            this._userDatabaseAPIStrategy = userDatabaseAPIStrategy;
            this._videoDatabaseAPIStrategy = videoDatabaseAPIStrategy;
        }

        #region Administrator API
        public List<AdministratorData> GetAdministrators()
        {
            return _administratorDatabaseAPIStrategy.GetAdministrators();
        }

        public AdministratorData GetAdministrator(int id)
        {
            return _administratorDatabaseAPIStrategy.GetAdministrator(id);
        }

        public AdministratorData GetAdministrator(string nickname, string password)
        {
            return _administratorDatabaseAPIStrategy.GetAdministrator(nickname, password);
        }

        public AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password)
        {
            return _administratorDatabaseAPIStrategy.CreateAdministrator(firstName, lastName, nickname, password);
        }

        public AdministratorData RemoveAdministrator(int id)
        {
            return _administratorDatabaseAPIStrategy.RemoveAdministrator(id);
        }

        public AdministratorData EditAdministrator(int id, string firstName, string lastName, string nickname)
        {
            return _administratorDatabaseAPIStrategy.EditAdministrator(id, firstName, lastName, nickname);
        }
        #endregion

        #region Report API
        public ReportData GetReport(long reportId)
        {
            return _reportDatabaseAPIStrategy.GetReport(reportId);
        }

        public ReportData CreateReport(long videoId, long userId, string description)
        {
            return _reportDatabaseAPIStrategy.CreateReport(videoId, userId, description);
        }

        public ReportData EditReport(long reportId, string description)
        {
            return _reportDatabaseAPIStrategy.EditReport(reportId, description);
        }

        public List<ReportData> GetReports()
        {
            return _reportDatabaseAPIStrategy.GetReports();
        }
        #endregion

        #region User API
        public UserData GetUser(long id)
        {
            return _userDatabaseAPIStrategy.GetUser(id);
        }

        public UserData BanUser(long id)
        {
            return _userDatabaseAPIStrategy.BanUser(id);
        }

        public List<UserData> GetUsers()
        {
            return _userDatabaseAPIStrategy.GetUsers();
        }
        #endregion

        #region Video API
        public VideoData GetVideo(long id)
        {
            return _videoDatabaseAPIStrategy.GetVideo(id);
        }

        public VideoData BanVideo(long id)
        {
            return _videoDatabaseAPIStrategy.BanVideo(id);
        }

        public List<VideoData> GetVideos()
        {
            return _videoDatabaseAPIStrategy.GetVideos();
        }
        #endregion
    }
}
