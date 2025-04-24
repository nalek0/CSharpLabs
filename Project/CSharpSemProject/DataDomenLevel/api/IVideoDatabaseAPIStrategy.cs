using DataDomenLevel.data;
using System.Collections.Generic;

namespace DataDomenLevel.api
{
    public interface IVideoDatabaseAPIStrategy
    {
        VideoData GetVideo(long id);
        VideoData BanVideo(long id);
        List<VideoData> GetVideos();
    }
}
