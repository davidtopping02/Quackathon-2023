using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelState: BaseState
{
    public TravelState() : base()
    {
        Debug.Log("In TravelState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("work");

    }

}