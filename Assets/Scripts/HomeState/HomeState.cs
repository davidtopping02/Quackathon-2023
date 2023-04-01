using UnityEngine;

public class HomeState : BaseState
{
    // main game scene
    public GameObject character;

    public HomeState() : base()
    {
        Debug.Log("In HomeState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {

        // loading the main game scene
        //SceneManager.LoadScene("Home");
    }

}