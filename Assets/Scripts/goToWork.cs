using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToWork : MonoBehaviour
{
   
   public void walkButton()
   {
        PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseStreangth, 20);
        GameController.Instance.player.StatsChangeEvent.Invoke(args);
        buttonClickHandler();
   }

   public void busButton()
   {
        if (GameController.Instance.player.Money >= 10)
        {
            PlayerStatsEventArgs args = new PlayerStatsEventArgs(PlayerStatsEventArgs.cmd.DecreaseMoney, 10);
            GameController.Instance.player.StatsChangeEvent.Invoke(args);
            buttonClickHandler();
        }
   }

   public void carButton()
   {
        if(GameController.Instance.player.HasCar)
        {
            buttonClickHandler();
        }
   }

    public bool makeButtonInActive()
    {
        return GameController.Instance.player.HasCar;
    }

    private void buttonClickHandler()
    {
        // Define the event type with a string parameter

        // Invoke the event with a string parameter
        State travelState = new TravelState();
        GameController.Instance.changeState.Invoke(travelState);
        Debug.Log("clicked");
    }
}

