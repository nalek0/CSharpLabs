using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.data
{
    class PlayerData
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public AddressData Address { get; set; }
        public TeamData Team { get; set; }
        public int NumberOfGoals { get; set; }
        public override string ToString()
        {
            return $"PlayerData[" +
                $" PlayerId={PlayerId}," +
                $" FirstName={FirstName}," +
                $" SecondName={SecondName}," +
                $" Address={Address}," +
                $" Team={Team}," +
                $" NumberOfGoals={NumberOfGoals}" +
                $" ]";
        }
    }
}
