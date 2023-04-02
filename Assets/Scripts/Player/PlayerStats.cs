using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats 
{
   
    [System.Serializable] public class customIntEvent : UnityEvent<int, int, int, int> { } //Lets me add a float arg to event call;
    public UnityEvent<PlayerStatsEventArgs> StatsChangeEvent = new UnityEvent<PlayerStatsEventArgs>();

    private int food = 20;
    public int Food { get { return food; } 
        private set {
            food = Math.Clamp(food, 0, 100);
            if(food<=0)
            {
                // Commence death
            }
        } 
    }// die on zero

    private int money = 50;
    public int Money { get { return money; } private set {
            if (money <= 0)
            {
                // Commence death
            }
        } 
    }// die on zero

    private int strength = 20;
    public int Strength { get { return strength; } private set {
            strength = Math.Clamp(strength, 0, 100);
            if (strength <= 0)
            {
                // Commence death
            }
        }
    }

    private int social = 20; 
    public int Social { get { return social; } private set {
            social = Math.Clamp(social, 0, 100);
            if (social <= 0)
            {
                // Commence death
            }
        } 
    }

    public bool HasCar { get; private set; }
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
        Money = 50;
        Strength = 20;
        Social = 20;
        HasCar = false;
        
    }

    private void OnChangeStats(PlayerStatsEventArgs arg0)
    {
        switch (arg0.Command)
        {
            case PlayerStatsEventArgs.cmd.IncreaseFood:
                food += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseFood:
                food -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseMoney:
                money += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseMoney:
                money -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseStreangth:
                strength += arg0.Value;
                Debug.Log(Strength + " ");
                break;
            case PlayerStatsEventArgs.cmd.DecreaseStreangth:
                strength -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.IncreaseSocial:
                social += arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.DecreaseSocial:
                social -= arg0.Value;
                break;
            case PlayerStatsEventArgs.cmd.HasCar:
                HasCar = arg0.Truth;
                break;
            
        }
        redrawUI();
    }

    public void redrawUI()
    {
        Debug.Log("called"); 
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
        
        // send bools for this 
        HasCar
        
    }
}
