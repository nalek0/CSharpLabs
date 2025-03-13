using System.Collections.Generic;

namespace CSharpSemProject.api
{
    public interface IVideoDatabaseAPIStrategy
    {
        VideoData GetVideo(long id);
        VideoData BanVideo(long id);
        List<VideoData> GetVideos();
    }
}
