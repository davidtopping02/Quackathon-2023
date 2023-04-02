using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Investment : MonoBehaviour
{

    public TextMeshProUGUI ISAText;
    public TextMeshProUGUI LISAText;
    public TextMeshProUGUI PensionText;
    // Start is called before the first frame update
    invest classInvest = new invest();

    public void ISA()
    {
        if (GameController.Instance.player.Money > 1)
        {
            Debug.Log("Invested");
            classInvest.addToISA();
            ISAText.text = "Amount in account: " + classInvest.getISA().ToString();
            updateMoney();
        }
    }
    public void Lifetime()
    {
        if (GameController.Instance.player.Money > 1)
        {
            classInvest.addTolifetimeISA();
            LISAText.text = "Amount in account: " + classInvest.getLISA().ToString();
            updateMoney();
        }
    }
    
    public void Pension()
    {
            if (GameController.Instance.player.Money > 1)
            {
                classInvest.addToPension();
                PensionText.text = "Amount in account: " + classInvest.getPension().ToString();
                updateMoney();
            }
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
