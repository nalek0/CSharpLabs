using System;
using System.Collections.Generic;
using Task2.data;

namespace Task2.api
{
    interface ITeamStadiumRelation
    {
        void Create(short teamId, short stadiumId);
        List<short> ReadTeams(short stadiumId);
        List<short> ReadStadiums(short teamId);
    }
}
