using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayStats : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI food;
    public TextMeshProUGUI strength;
    public TextMeshProUGUI social;
    private void Awake()
    {
        money.text = "Money = " + GameController.Instance.player.GetComponent<PlayerStats>().Money.ToString();
        food.text = "Food = " + GameController.Instance.player.GetComponent<PlayerStats>().Food.ToString();
        strength.text = "Strength = " + GameController.Instance.player.GetComponent<PlayerStats>().Strength.ToString();
        social.text = "Social = " + GameController.Instance.player.GetComponent<PlayerStats>().Social.ToString();
    }
}
