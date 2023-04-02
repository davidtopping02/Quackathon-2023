using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Services.CloudSave;
using System;
using System.Threading.Tasks;

public class EndOfDayStats : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI food;
    public TextMeshProUGUI strength;
    public TextMeshProUGUI social;
    private void Awake()
    {
        money.text = "Money = " + GameController.Instance.player.Money.ToString();
        food.text = "Food = " + GameController.Instance.player.Food.ToString();
        strength.text = "Strength = " + GameController.Instance.player.Strength.ToString();
        social.text = "Social = " + GameController.Instance.player.Social.ToString();
        CloudSaceAsync();
    }

    
    public void GoToNextDay()
    {
        State state = new HomeState();
        GameController.Instance.changeState.Invoke(state);
       
    }

    private async Task CloudSaceAsync()
    {
        var data = new Dictionary<string, object> { { "PlayerData", GameController.Instance.player } };
        await CloudSaveService.Instance.Data.ForceSaveAsync(data);
    }
}
