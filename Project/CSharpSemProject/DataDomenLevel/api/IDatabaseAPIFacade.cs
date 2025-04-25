using DataDomenLevel.data;
using System.Collections.Generic;

namespace DataDomenLevel.api
{
    public interface IDatabaseAPIFacade
    {
        #region Administrator API
        AdministratorData GetAdministrator(long id);

        AdministratorData GetAdministrator(string nickname, string password);

        AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password);

        AdministratorData RemoveAdministrator(long id);

        AdministratorData EditAdministrator(long id, string firstName, string lastName, string nickname);
        #endregion

        #region Report API
        ReportData GetReport(long reportId);

        ReportData CreateReport(long videoId, long userId, string description);

        ReportData EditReport(long reportId, string description);

        List<ReportData> GetReports();
        #endregion

        #region User API
        UserData GetUser(long id);

        UserData BanUser(long id);

        List<UserData> GetUsers();
        #endregion

        #region Video API
        VideoData GetVideo(long id);

        VideoData BanVideo(long id);

        List<VideoData> GetVideos();
        #endregion
    }
}
