using System;
using System.Collections.Generic;
using Task2.data;

namespace Task2.api
{
    interface IPlayersAPI
    {
        PlayerData Create(string firstName, string secondName);
        PlayerData Read(int playerId);
        List<PlayerData> ReadAll();
        void Update(int playerId, PlayerData playerData);
        void Delete(int playerId);
    }
}
