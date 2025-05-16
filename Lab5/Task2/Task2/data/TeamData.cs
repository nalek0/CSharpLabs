using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.data
{
    class TeamData
    {
        public short TeamId { get; set; }
        public string TeamName { get; set; }
        public int EstYear { get; set; }

        public override string ToString()
        {
            return $"TeamData[" +
                $" TeamId={TeamId}," +
                $" TeamName={TeamName.TrimEnd()}," +
                $" EstYear={EstYear}" +
                $" ]";
        }
    }
}
