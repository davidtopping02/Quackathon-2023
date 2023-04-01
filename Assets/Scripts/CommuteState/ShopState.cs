using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopState: BaseState
{
    public ShopState() : base()
    {
        Debug.Log("In TravelState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("store");

    }

}