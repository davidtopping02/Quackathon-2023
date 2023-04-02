using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats
{
   
    [System.Serializable] public class customIntEvent : UnityEvent<int, int, int, int> { } //Lets me add a float arg to event call;
    public UnityEvent<PlayerStatsEventArgs> StatsChangeEvent = new UnityEvent<PlayerStatsEventArgs>();


    public UnityEvent<String> death = new UnityEvent<String>();

    private int food = 20;
    public int Food
    {
        get { return food; }
        private set
        {

            food = Math.Clamp(value, 0, 100);
            if (food <= 0)
            {
                Debug.Log("death");
                State state = new FoodDeath();
                GameController.Instance.changeState.Invoke(state);
            }
        }
    }// die on zero

    private int money = 5;
    public int Money
    {
        get { return money; }
        private set
        {
            money = value;
            if (money <= 0)
            {
                Debug.Log("death");
                State state = new MoneyDeath();
                GameController.Instance.changeState.Invoke(state);
            }
        }
    }// die on zero

    private int strength = 50;
    public int Strength
    {
        get { return strength; }
        private set
        {
            strength = Math.Clamp(value, 0, 100);

            if (strength <= 0)
            {
                Debug.Log("death");
                State state = new StrengthDeath();
                GameController.Instance.changeState.Invoke(state);
            }
        }
    }

    private int social = 20;
    public int Social
    {
        get { return social; }
        private set
        {
            social = Math.Clamp(value, 0, 100);
            if (social <= 0)
            {
                Debug.Log("death");
                State state = new SocialDeath();
                GameController.Instance.changeState.Invoke(state);
            }
        }
    }

    public bool HasCar { get; private set; }
    public bool HasDied { get; private set; }
    public uint DaysSurvived { get; private set; }

    public customIntEvent updateUI = new customIntEvent();
    private void Start()
    {
        Debug.Log(Money);
    }
    public PlayerStats()
    {
        StatsChangeEvent.AddListener(OnChangeStats);
        Food = 20;
        Money = 5;
        Strength = 50;
        Social = 20;
        HasCar = false;
        HasDied = false;
        
    }

    private void OnChangeStats(PlayerStatsEventArgs arg0)
    {
        switch (arg0.Command)
        {
            case PlayerStatsEventArgs.cmd.IncreaseFood:
                Food += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseFood:
                Food -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseMoney:
                Money += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseMoney:
                Money -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseStreangth:
                Strength += arg0.Value;
                Debug.Log(Strength + " ");
                break;
            case PlayerStatsEventArgs.cmd.DecreaseStreangth:
                Strength -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseSocial:
                Social += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseSocial:
                Social -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.HasCar:
                HasCar = arg0.Truth;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseDays:
                DaysSurvived++;
                break;

        }
        redrawUI();
    }

    public void redrawUI()
    {
        updateUI.Invoke(Money, Food, Strength, Social);
    }
}
public class PlayerStatsEventArgs : EventArgs
{
    public cmd Command;
    public int Value;
    public bool Truth;
    public PlayerStatsEventArgs(cmd command, int val)
    {
        Command = command;
        Value = val;
    }
    public PlayerStatsEventArgs(cmd command, bool val)
    {
        Command = command;
        Truth = val;
    }
    /// <summary>
    ///  Make sure while using this send the corrct value type 
    /// </summary>
    public enum cmd
    {
        // send Ints for this
        IncreaseFood,
        DecreaseFood,
        IncreaseMoney,
        DecreaseMoney,
        IncreaseStreangth,
        DecreaseStreangth,
        IncreaseSocial,
        DecreaseSocial,
        IncreaseDays,
        
        // send bools for this 
        HasCar
        
    }
}
