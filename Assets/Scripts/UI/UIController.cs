using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Image foodImage;
    public Image socialImage;
    public Image strengthImage;
    public TextMeshProUGUI Money;


    private void Start()
    {
        GameController.Instance.player.GetComponent<PlayerStats>().updateUI.AddListener(redrawUI);
        redrawUI(
            GameController.Instance.player.GetComponent<PlayerStats>().Money,
            GameController.Instance.player.GetComponent<PlayerStats>().Food,
            GameController.Instance.player.GetComponent<PlayerStats>().Strength,
            GameController.Instance.player.GetComponent<PlayerStats>().Social
            );
    }

    public void redrawUI(int money, int food, int strength, int social)
    {

        foodImage.fillAmount = food / 100f;
        socialImage.fillAmount = social / 100f;
        strengthImage.fillAmount = strength / 100f;
        Money.text = money.ToString();
    }
}
