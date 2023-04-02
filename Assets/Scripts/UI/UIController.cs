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
        GameController.Instance.player.updateUI.AddListener(redrawUI);
        redrawUI(
            GameController.Instance.player.Money,
            GameController.Instance.player.Food,
            GameController.Instance.player.Strength,
            GameController.Instance.player.Social
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
