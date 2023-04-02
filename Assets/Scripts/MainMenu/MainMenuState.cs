using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : BaseState
{
    public MainMenuState() : base()
    {
    }
    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("IntroScreen");
    }
}
