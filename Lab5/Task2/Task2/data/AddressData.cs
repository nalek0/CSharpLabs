using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.data
{
    class AddressData
    {
        public short AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }

        public override string ToString()
        {
            return $"AddressData[" +
                $" AddressId={AddressId}," +
                $" Country={Country.TrimEnd()}," +
                $" City={City.TrimEnd()}," +
                $" Street={Street.TrimEnd()}," +
                $" Building={Building.TrimEnd()}," +
                $" Apartment={Apartment.TrimEnd()}" +
                $" ]";
        }
    }
}
