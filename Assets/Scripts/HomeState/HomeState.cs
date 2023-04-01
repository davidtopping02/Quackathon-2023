using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeState : BaseState
{
    public HomeState() : base()
    {
        Debug.Log("In HomeState");
    }


    void start()
    {
    }

    public override void OnEnter()
    {
        SceneManager.LoadScene("gym");
        Debug.Log(GameController.Instance.player.GetComponent<PlayerStats>().Money);

    }

}