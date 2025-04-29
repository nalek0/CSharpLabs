using System;
using Task2.data;

namespace Task2.api
{
    interface IPlayersAPI
    {
        PlayerData Create(string firstName, string secondName);
        PlayerData Read(int playerId);
        void Update(int playerId, PlayerData playerData);
        void Delete(int playerId);
    }
}
