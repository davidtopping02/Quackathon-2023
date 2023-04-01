using UnityEngine;
using UnityEngine.SceneManagement;

public class BarState : BaseState
{
    public BarState() : base()
    {
        Debug.Log("In TravelState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("bar");

    }

}