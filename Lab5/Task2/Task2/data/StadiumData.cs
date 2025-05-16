using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.data
{
    class StadiumData
    {
        public short StadiumId { get; set; }
        public string StadiumName { get; set; }
        
        public override string ToString()
        {
            return $"StadiumData[" +
                $" StadiumId={StadiumId}," +
                $" StadiumName={StadiumName.TrimEnd()}" +
                $" ]";
        }
    }
}
