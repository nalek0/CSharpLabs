using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSemProject.api
{
    interface IVideoDatabaseAPIStrategy
    {
        VideoData GetVideo(long id);
        VideoData BanVideo(long id);
        List<VideoData> GetVideos();
    }
}
