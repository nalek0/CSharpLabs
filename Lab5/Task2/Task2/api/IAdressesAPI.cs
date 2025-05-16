using System;
using System.Collections.Generic;
using Task2.data;

namespace Task2.api
{
    interface IAdressesAPI
    {
        AddressData Create(string country, string city, string street, string building, string apartment);
        AddressData Read(short addressId);
        void Update(short addressId, AddressData addressData);
        void Delete(short addressId);
    }
}
