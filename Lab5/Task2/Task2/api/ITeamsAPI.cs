using System;
using System.Collections.Generic;
using Task2.data;

namespace Task2.api
{
    interface ITeamsAPI
    {
        TeamData Create(string teamName, int estYear);
        TeamData Read(short teamId);
        void Update(short teamId, TeamData addressData);
        void Delete(short teamId);
    }
}
