using CSharpSemProject;
using CSharpSemProject.api;
using System.Collections.Generic;

namespace SemProjectUnitTesting.mocks
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
