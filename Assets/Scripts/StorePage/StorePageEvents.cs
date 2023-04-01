using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePageEvents : MonoBehaviour
{
    public void BuyGoodFood()
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseFood, 10);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseStreangth, 10);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
    }
    public void BuyBadFood() 
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseFood, 5);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseStreangth, 5);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
    }
    public void BuymehFood() 
    { 
    }

    public void BuyCar()
    {
        
    }
}
