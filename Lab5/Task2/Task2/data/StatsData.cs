using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.data
{
    class StatsData
    {
        public short TeamId { get; set; }
        public int NumberOfPlayers { get; set; }
        public int NumberOfStadiums { get; set; }
        public float AverageGoalsPerPlayer { get; set; }

        public override string ToString()
        {
            return $"StatsData[" +
                $" TeamId={TeamId}," +
                $" NumberOfPlayers={NumberOfPlayers}," +
                $" NumberOfStadiums={NumberOfStadiums}," +
                $" AverageGoalsPerPlayer={AverageGoalsPerPlayer}" +
                $" ]";
        }
    }
}
