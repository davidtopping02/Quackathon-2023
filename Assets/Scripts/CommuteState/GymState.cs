using UnityEngine;
using UnityEngine.SceneManagement;

public class GymState : BaseState
{
    public GymState() : base()
    {
        Debug.Log("In TravelState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("gym");

    }

}