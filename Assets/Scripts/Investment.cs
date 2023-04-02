using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investment : MonoBehaviour
{
    // Start is called before the first frame update
    invest classInvest = new invest();





   
    public void ISA()
    {
        classInvest.addToISA();
        updateMoney();
    }
    public void Lifetime()
    {
        classInvest.addTolifetimeISA();
        updateMoney();
    }
    
    public void Pension()
    {
        classInvest.addToPension();
        updateMoney();
    }
    public void RemoveMoney()
    {
        classInvest.removeFromISA();
        addMoney();
    }

    private void updateMoney()
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 1);
        GameController.Instance.player.StatsChangeEvent.Invoke(args);
    }
    private void addMoney()
    {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.IncreaseMoney, 1);
        GameController.Instance.player.StatsChangeEvent.Invoke(args);
    }
}
