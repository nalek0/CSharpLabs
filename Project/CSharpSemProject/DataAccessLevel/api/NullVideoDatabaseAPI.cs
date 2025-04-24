using DataDomenLevel.data;
using DataDomenLevel.api;
using System.Collections.Generic;

namespace DataAccessLevel.api
{
    public class NullVideoDatabaseAPI : IVideoDatabaseAPIStrategy
    {
        public VideoData BanVideo(long id)
        {
            throw new System.NotImplementedException();
        }

        public VideoData GetVideo(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<VideoData> GetVideos()
        {
            throw new System.NotImplementedException();
        }
    }
}
