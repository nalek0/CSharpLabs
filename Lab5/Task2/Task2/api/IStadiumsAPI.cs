using System;
using System.Collections.Generic;
using Task2.data;

namespace Task2.api
{
    interface IStadiumsAPI
    {
        StadiumData Create(string stadiumName);
        StadiumData Read(short stadiumId);
        void Update(short stadiumId, StadiumData addressData);
        void Delete(short stadiumId);
    }
}
