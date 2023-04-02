using UnityEngine;
using UnityEngine.SceneManagement;

public class InvestState : BaseState
{
    public InvestState() : base()
    {
        Debug.Log("In TravelState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("bank");

    }

}