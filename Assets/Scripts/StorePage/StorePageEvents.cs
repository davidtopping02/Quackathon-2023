using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorePageEvents : MonoBehaviour
{
    // just a data class to make it easier to change number arround 
    // prices 
    int goodFoodPrice = 10; 
    int mehFoodPrice = 8; 
    int badFoodPrice = 3; 
    int carPricve = 500;
    // nagative impacts 

    // positive inpacts 
    public void BuyGoodFood()
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseFood, 10);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseStreangth, 10);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 10);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
    }
    public void BuyBadFood() 
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseFood, 5);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseStreangth, 5);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 3);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
    }
    public void BuymehFood() 
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseFood, 5);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney,8);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
    }

    public void BuyCar()
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.HasCar,true);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args); 
        args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 300);
        GameController.Instance.player.GetComponent<PlayerStats>().StatsChangeEvent.Invoke(args);
    }
}
