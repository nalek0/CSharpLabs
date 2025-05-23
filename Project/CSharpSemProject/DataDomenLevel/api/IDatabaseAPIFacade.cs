using DataDomenLevel.data;
using System.Collections.Generic;

namespace DataDomenLevel.api
{
    public interface IDatabaseAPIFacade
    {
        #region Administrator API
        List<AdministratorData> GetAdministrators();

        AdministratorData GetAdministrator(int id);

        AdministratorData GetAdministrator(string nickname, string password);

        AdministratorData CreateAdministrator(string firstName, string lastName, string nickname, string password);

        AdministratorData RemoveAdministrator(int id);

        AdministratorData EditAdministrator(int id, string firstName, string lastName, string nickname);
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
