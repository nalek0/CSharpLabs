using System;
using System.Collections.Generic;
using Task2.data;

namespace Task2.api
{
    interface IPlayersAPI
    {
        #region CRUD operations
        PlayerData Create(string firstName, string secondName, short? addressId, short? teamId, int numberOfGoals);
        
        PlayerData Read(short playerId);
        
        List<PlayerData> ReadAll();
        
        void Update(short playerId, PlayerData playerData);
        
        void Delete(short playerId);
        #endregion

        #region Table relations
        List<PlayerData> ReadTeamPlayers(short teamId);
        #endregion
    }
}
