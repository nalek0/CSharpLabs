using System;
using System.Collections.Generic;

namespace CSharpSemProject.api.impl
{
    class LocalVideoDatabaseAPI : IVideoDatabaseAPIStrategy
    {
        private List<VideoData> _videos = new List<VideoData>()
        {
            new VideoData() { VideoId = 1, UserId = 1, Description = "Coolest video in the world" },
            new VideoData() { VideoId = 2, UserId = 2, Description = "No description" }
        };

        public VideoData GetVideo(long id)
        {
            throw new NotImplementedException();
        }

        public VideoData BanVideo(long id)
        {
            throw new NotImplementedException();
        }

        public List<VideoData> GetVideos()
        {
            return _videos;
        }
    }
}
