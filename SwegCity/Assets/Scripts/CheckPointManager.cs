using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private class PlayerData
    {
        public Player Player;
        public int PlayerPos;
        public int LastCheckPoint;

        public PlayerData(Player player, int playerPos, int lastCheckPoint)
        {
            Player = player;
            PlayerPos = playerPos;
            LastCheckPoint = lastCheckPoint;
        }
    }

    [SerializeField] private CheckPoint[] checkPoints;
    [SerializeField] private Player[] players;

    private List<PlayerData> playerDataList;

    private void Awake()
    {
        playerDataList = new List<PlayerData>();

        foreach (Player player in players)
        {
            playerDataList.Add(new PlayerData(player, players.Length, 0));
        }
    }

    private void Update()
    {
        UpdatePlayerPos();
        CalculatePosition();
    }

    private void UpdatePlayerPos()
    {
        for (int i = 0; i < playerDataList.Count - 1; i++)
        {
            playerDataList[i].Player.SetCurrentPos(playerDataList[i].PlayerPos);
        }
    }

    private void CalculatePosition()
    {
        int playerDataListLength = playerDataList.Count - 1;

        // sort list
        for (int i = 0; i < playerDataListLength; i++)
        {
            PlayerData currentListItem = playerDataList[i];
            PlayerData nextListItem = playerDataList[i + 1];
            if (nextListItem != null && nextListItem.LastCheckPoint > currentListItem.LastCheckPoint)
            {
                playerDataList.Remove(nextListItem);
                playerDataList.Insert(0, nextListItem);
                i = 0;
            }
        }

        // update position
        for (int i = 0; i < playerDataListLength; i++)
        {
            playerDataList[i].PlayerPos = i + 1;
        }
    }

    private void PlayerDrivingWrongWay(Player player, bool isDrivingWrongWay)
    {
        player.IsDrivingWrongWay = isDrivingWrongWay;
    }

    public void UpdateCheckPointInPlayerDataList(Player player, int checkPointPos)
    {
        foreach (PlayerData playerData in playerDataList)
        {
            if (playerData.Player == player)
            {
                if (playerData.LastCheckPoint == 0 || playerData.LastCheckPoint < checkPointPos)
                {
                    playerData.LastCheckPoint = checkPointPos;
                    PlayerDrivingWrongWay(player, false);
                }
                else
                {
                    playerData.LastCheckPoint = checkPointPos;
                    PlayerDrivingWrongWay(player, true);
                }
            }
        }
    }
}

