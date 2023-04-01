using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseState : BaseState
{
    public HouseState() : base()
    {
        Debug.Log("In TravelState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("house");

    }

}