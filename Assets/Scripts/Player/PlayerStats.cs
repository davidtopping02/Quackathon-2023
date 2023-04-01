using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [System.Serializable] public class customIntEvent : UnityEvent<int, int, int, int> { } //Lets me add a float arg to event call;

    [SerializeField]
    public int Food = 100;

    [SerializeField]
    public int Money = 100;

    [SerializeField]
    public int Strength = 100;

    [SerializeField]
    public int Social = 100;

    public customIntEvent updateUI;

    public void updateMoney(int diff)
    {
        this.Money += diff;
        redrawUI();
    }

    public void updateFood(int diff)
    {
        this.Food += diff;
        redrawUI();
    }

    public void updateStrength(int diff)
    {
        this.Strength += diff;
        redrawUI();
    }

    public void updateSocial(int diff)
    {
        this.Social += diff;
        redrawUI();
    }

    public void redrawUI()
    {
        updateUI.Invoke(Money, Food, Strength, Social);
    }

}
