using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [System.Serializable] public class customIntEvent : UnityEvent<int, int, int, int> { } //Lets me add a float arg to event call;
    public UnityEvent<PlayerStatsEventArgs> StatsChangeEvent = new UnityEvent<PlayerStatsEventArgs>();

    public int Food { get; private set; }// die on zero

    public int Money { get; private set; }// die on zero

    public int Strength { get; private set; }

    public int Social { get; private set; }

    public bool HasCar { get; private set; }

    public customIntEvent updateUI;
    private void Start()
    {
        Debug.Log(Money);
    }
    public PlayerStats()
    {
        StatsChangeEvent.AddListener(OnChangeStats);
        Food = 100;
        Money = 100;
        Strength = 100;
        Social = 100;
        HasCar = false;
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
